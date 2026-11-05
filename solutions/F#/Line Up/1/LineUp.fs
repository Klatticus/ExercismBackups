module LineUp

let (|First|Second|Third|Other|) (numStr:string) =
    if numStr.EndsWith("1") && not (numStr.EndsWith("11")) then First
    elif numStr.EndsWith("2") && not (numStr.EndsWith("12")) then Second
    elif numStr.EndsWith("3") && not (numStr.EndsWith("13")) then Third
    else Other

let generateGreeting name number suffix =
    $"{name}, you are the {number}{suffix} customer we serve today. Thank you!"

let format (name: string) (number: int): string =
    let partialGreeting = generateGreeting name number
    match string number with
    | First -> partialGreeting "st"
    | Second -> partialGreeting "nd"
    | Third -> partialGreeting "rd"
    | Other -> partialGreeting "th"