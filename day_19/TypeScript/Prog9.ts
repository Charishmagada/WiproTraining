//constructor
var Emp = (function () {
    function Employ(empno, name, basic) {
        this.empno = empno;
        this.name = name;
        this.basic = basic;
    }
    return Employ;
}());
var obj = new Emp(1, "Siri", 84823);
console.log("Employ No ".concat(obj.empno, "\nEmploy Name")
.concat(obj.name, "\nSalary ").concat(obj.basic));