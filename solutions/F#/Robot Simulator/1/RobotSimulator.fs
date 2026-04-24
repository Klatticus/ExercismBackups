module RobotSimulator

type Direction = North | East | South | West
type Position = int * int
type Robot = {
    Direction:Direction
    Position:Position
}

let create direction position = {Direction = direction; Position = position}

let turnRight robot =
    let newDirection =
        match robot.Direction with
        | North -> East
        | East -> South
        | South -> West
        | West -> North
    {robot with Direction = newDirection}
    
let turnLeft robot =
    let newDirection =
        match robot.Direction with
        | North -> West
        | East -> North
        | South -> East
        | West -> South
    {robot with Direction = newDirection}
    
let advance robot =
    match robot with
    | {Direction = North; Position = (currentX, currentY)} -> {robot with Position = (currentX, currentY + 1)}
    | {Direction = East; Position = (currentX, currentY)} -> {robot with Position = (currentX + 1, currentY)}
    | {Direction = South; Position = (currentX, currentY)} -> {robot with Position = (currentX, currentY - 1)}
    | {Direction = West; Position = (currentX, currentY)} -> {robot with Position = (currentX - 1, currentY)}

let commandRobot robot command =
    match command with
    | 'R' -> turnRight robot
    | 'L' -> turnLeft robot
    | 'A' -> advance robot
    | _ -> robot

let move instructions robot =
    instructions
    |> Seq.fold commandRobot robot
