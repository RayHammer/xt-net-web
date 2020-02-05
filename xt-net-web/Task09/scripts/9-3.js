(function() {
    var formElements = document.forms.taskForm.elements;
    var available = formElements.available;
    var selected = formElements.selected;

    function moveOption(select, option) {
        select.options[select.options.length] = option;
    }

    function selectMove(from, to) {
        var i = 0;
        while (i < from.options.length) {
            if (from.options[i].selected) {
                moveOption(to, from.options[i]);
            } else {
                i++;
            }
        }
    }

    function selectMoveAll(from, to) {
        while (0 < from.options.length) {
            moveOption(to, from.options[0]);
        }
    }

    formElements.selectAll.onclick = function() {
        selectMoveAll(available, selected);
    }

    formElements.select.onclick = function() {
        selectMove(available, selected);
    }

    formElements.deselect.onclick = function() {
        selectMove(selected, available);
    }

    formElements.deselectAll.onclick = function() {
        selectMoveAll(selected, available);
    }

    moveOption(available, new Option("Option 1", null))
    moveOption(available, new Option("Option 2", null))
    moveOption(available, new Option("Option 3", null))

    moveOption(selected, new Option("Option 4", null))
    moveOption(selected, new Option("Option 5", null))
    moveOption(selected, new Option("Option 6", null))
})()