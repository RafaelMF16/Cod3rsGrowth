QUnit.config.autostart = false;

sap.ui.require([
	"sap/ui/core/Core", 
	"ui5/codersgrowth/test/integration/AllJourney"
], async(Core) => {
	"use strict";

	await Core.ready();

	sap.ui.require([
		
	], () => {
		QUnit.start();
	});
});