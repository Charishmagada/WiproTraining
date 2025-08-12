interface IEmployee {
    empno : number;
    name : string;
    salary : number;
}

const employee1 : IEmployee = {
    empno:1,
    name:"Prasanna",
    salary:88234
}

console.log(`Employee No ${employee1.empno} Employee Name ${employee1.name} Salary ${employee1.salary}`)