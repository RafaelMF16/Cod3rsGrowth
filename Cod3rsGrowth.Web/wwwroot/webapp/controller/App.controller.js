sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/m/MessageToast",
    "sap/ui/model/json/JSONModel",
    "sap/ui/model/resource/ResourceModel"
 ], (Controller, MessageToast, JSONModel, ResourceModel) => {
    "use strict";
 
    return Controller.extend("ui5.codersgrowth.controller.App", {
      onInit() {
          const i18nModel = new ResourceModel({
             bundleName: "ui5.codersgrowth.i18n.i18n"
          });
          this.getView().setModel(i18nModel, "i18n");
       },
 
       onShowHello() {
          const oBundle = this.getView().getModel("i18n").getResourceBundle();
          const sMsg = oBundle.getText("mensagemDeOla");
 
          MessageToast.show(sMsg);
       }
    });
 });