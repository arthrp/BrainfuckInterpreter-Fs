open System
open BrainfuckInterpreter_Fs.Interpreter

[<EntryPoint>]
let main argv =
    let result = interpretBrainfuck ">++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++."
    Console.WriteLine result
    0