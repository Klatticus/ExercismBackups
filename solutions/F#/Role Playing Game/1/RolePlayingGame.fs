module RolePlayingGame

open System

type Player = { 
    Name: string option
    Level: int
    Health: int
    Mana: int option
}

let introduce (player: Player): string = player.Name |> Option.defaultValue "Mighty Magician"

let (|DeadNewbie|DeadVeteran|Alive|) player =
    match player with
    | {Health = 0; Level = level} when level < 10 -> DeadNewbie
    | {Health = 0} -> DeadVeteran
    | _ -> Alive

let revive (player: Player): Player option = 
    match player with
    | DeadNewbie -> Some {player with Health = 100; Mana = None}
    | DeadVeteran -> Some {player with Health = 100; Mana = Some 100}
    | Alive -> None

let castSpell (manaCost: int) (player: Player): Player * int =
    let manaPool = player.Mana |> Option.defaultValue 0
    let updatedMana = manaPool - manaCost
    let spellSuccess = updatedMana >= 0
    let playerHasMana = Option.isSome player.Mana
    match (playerHasMana, spellSuccess) with
    | true, true -> ({player with Mana = Some updatedMana}, manaCost * 2)
    | true, false -> (player, 0)
    | false, _ -> ({player with Health = Math.Max(0, (player.Health - manaCost))}, 0)
