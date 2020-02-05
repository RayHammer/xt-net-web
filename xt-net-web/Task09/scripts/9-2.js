(function() {
    var form = document.forms.taskForm;

    function solve() {
        var str = form.input.value;
        var str1 = "";
        
        function calc(str) {
            const numRegex = "(-?[0-9]+(?:[\.][0-9]+)?) ?"
            const opRegex = "([-\+\*\/=]) ?"
            const regex = RegExp(numRegex + opRegex + "(.*)");
            var match, exp = [], res;
            var i = 0;

            match = str.match(regex);
            while (match != null) {
                var num = match[1];
                var op = match[2];
                var rest = match[3];
                exp.push(num);
                exp.push(op);
                match = rest.match(regex);
            }

            if (exp.length == 0) {
                return null;
            }

            res = parseFloat(exp[0]);
            while (i < exp.length) {
                var op = exp[i++];
                switch (op) {
                case "+":
                    res += parseFloat(exp[i++]);
                    break;
                case "-":
                    res -= parseFloat(exp[i++]);
                    break;
                case "*":
                    res *= parseFloat(exp[i++]);
                    break;
                case "/":
                    res /= parseFloat(exp[i++]);
                    break;
                case "=":
                    if (i != exp.length) {
                        return null;
                    }
                    return res.toFixed(2);
                }
            }
        }

        str1 = calc(str);

        form.output.value = str1;
    }

    form.start.addEventListener("click", solve);
})()