/* Message bus */
EuhCrm = {
    bus: {
        _subscribers: [],
        publish: function(type, msg) {
            if (!this._subscribers[type]) {
                return;
            }

            for (var i in this._subscribers[type]) {
                this._subscribers[type][i](msg);
            }
        },
        subscribe: function(type, handler) {
            if (!this._subscribers[type]) {
                this._subscribers[type] = [];
            }
            this._subscribers[type].push(handler);
        },
        messagetype: {
            DocumentReady: "doc_ready",
            NotifyComponentSelect: "notify_comp_select"
        }
    }
};