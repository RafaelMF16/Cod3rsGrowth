sap.ui.define([
    'sap/ui/test/Opa5',
    './arrangements/Startup',
    './JogoJourney',
    './AdicionarJogoJourney',
    './DetalhesJogoJourney',
    './EditarJogoJourney'
], function(Opa5, Startup) {
    'use strict';

    Opa5.extendConfig({
		arrangements: new Startup(),
		viewNamespace: "ui5.codersgrowth.app",
		autoWait: true
	});
});