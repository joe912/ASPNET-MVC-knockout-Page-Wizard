function TriggersViewModel() {
    var self = this;

    self.triggers = ko.observableArray();

    self.removeTrigger = function (trigger) {
        self.triggers.remove(trigger);
    }

    self.addTrigger = function () {
        self.triggers.push({
            triggerId: 0,
            triggerName: 'a new trigger'
        });
        $("#EditingTriggerOrAlert").val("True");
        var newTriggers1 = ko.toJSON(self.triggers);
        $("#Triggers").val(newTriggers1);

        $("form").submit();
    }
}

$(function () {
    var initialTriggers = JSON.parse($("#Triggers").val());

    // initialize 
    var viewModel = new TriggersViewModel();
    $.each(initialTriggers, function (index, item) {
        viewModel.triggers.push(item);
    });

    ko.applyBindings(viewModel, $("#divTriggers")[0]);
});