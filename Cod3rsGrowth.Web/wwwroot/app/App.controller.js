sap.ui.define([
   "ui5/codersgrowth/app/BaseController"
], (BaseController) => {
   "use strict";
   
   const NAMESPACE_DA_CONTROLLER_APP = "ui5.codersgrowth.app.App";

   return BaseController.extend(NAMESPACE_DA_CONTROLLER_APP, {
      onInit: function () {
      },

      _alternarStatusMenuLateralExpandido: function() {
			return RepositorioDasPreferenciasDoUsuario
				.AtualizarPreferencias(this._idDoUsuario, {
					menuLateralExpandido: this.toolPage.getSideExpanded()
				})
				.catch(x => this.mostrarErroENavegarParaLogin(x));
		},

      aoClicarEmExpandirMenuLateral: function() {
         var sideExpanded = this.toolPage.getSideExpanded();
         this.toolPage.setSideExpanded(!sideExpanded);
         this._alternarStatusMenuLateralExpandido();
      },
   });
});