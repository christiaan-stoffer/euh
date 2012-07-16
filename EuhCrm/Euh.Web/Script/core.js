/// <reference path="~/Script/messagebus.js" />
/* Core */
$(function () {
    EuhCrm.bus.publish(EuhCrm.bus.messagetype.DocumentReady, null);
});