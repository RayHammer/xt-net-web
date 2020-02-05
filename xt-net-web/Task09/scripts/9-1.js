(function() {
    var form = document.forms.taskForm;

    function solve() {
        var str = form.input.value + '\0';
        var str1 = "";
        var dictionary = [];

        function isSeparator(chr) {
            var separators = [' ', '\t', '.', ',', ':', ';', '?', '!', '\0'];

            for (var i = 0; i < separators.length; i++) {
                if (chr == separators[i]) {
                    return true;
                }
            }
            return false;
        }
        
        for (var i = 0; i < str.length; i++) {
            var chr = str[i].toLowerCase();
            if (!isSeparator(chr)) {
                str1 += chr;
                continue;
            }
            if (str1.length == 0) {
                continue;
            }
            for (var j = 0; j < str1.length - 1; j++) {
                var chr = str1[j];
                if (str1.indexOf(chr, j + 1) != -1) {
                    dictionary[chr] = true;
                }
            }
            str1 = "";
        }

        console.warn(dictionary);

        str1 = "";

        for (var i = 0; i < str.length - 1; i++) {
            var chr = str[i];
            if (dictionary[chr.toLowerCase()] != true) {
                str1 += chr;
            }
        }

        form.output.value = str1;
    }

    form.start.addEventListener("click", solve);
})()