module InterestIsInteresting

open System

let interestRate (balance: decimal): single =
    if balance < 0.0m then 3.213f
    elif balance < 1000.0m then 0.5f
    elif balance < 5000.0m then 1.621f
    else 2.475f

let interestMultiplier (rate:single):decimal = (decimal rate) / 100.0m

let interest (balance: decimal): decimal = balance * (balance |> interestRate |> interestMultiplier)

let annualBalanceUpdate(balance: decimal): decimal = balance + (interest balance)

let amountToDonate(balance: decimal) (taxFreePercentage: float): int =
   taxFreePercentage
   |> (fun percent -> percent / 100.0)
   |> (*) 2.0
   |> decimal
   |> (*) balance
   |> Decimal.Floor
   |> int
   |> max 0
