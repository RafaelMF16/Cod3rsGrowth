QUnit.config.autostart = false;

sap.ui.require(["sap/ui/core/Core"], async(Core) => {
	"use strict";

	await Core.ready();

	sap.ui.require([
		"ui5/codersgrowth/localService/mockserver",
		"ui5/codersgrowth/test/integration/NavigationJourney"
	], (mockserver) => {
		// initialize the mock server
		mockserver.init();
		QUnit.start();
	});
});