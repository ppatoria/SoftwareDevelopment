type Employee = { name : string }
let  PrintEmployees e = printfn "%s" e.name
type Manager  =
    { name : string; emp : Employee }
    member this.EmployeeName =  this.emp.name
let  PrintManager mg = printfn "%s%s" mg.name, mg.employee
