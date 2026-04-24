module PizzaPricing

type Pizza =
    | Margherita
    | Caprese
    | Formaggio
    | ExtraSauce of Pizza
    | ExtraToppings of Pizza

let rec calculatePizzaPrice pizza total =
    match pizza with
    | Margherita -> total + 7
    | Caprese -> total + 9
    | Formaggio -> total + 10
    | ExtraSauce pie -> calculatePizzaPrice pie (total + 1)
    | ExtraToppings pie -> calculatePizzaPrice pie (total + 2)

let pizzaPrice (pizza: Pizza): int = calculatePizzaPrice pizza 0

let orderPrice(pizzas: Pizza list): int =
    let surcharge =
        match pizzas.Length with
        | 1 -> 3
        | 2 -> 2
        | _ -> 0
    let pizzaTotal =
        pizzas
        |> List.map pizzaPrice
        |> List.sum
    pizzaTotal + surcharge
