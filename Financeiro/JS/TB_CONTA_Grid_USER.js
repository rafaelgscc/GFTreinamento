var $j = jQuery.noConflict();
$j(document).ready(function(){
	var InitMask = function () {
		$j('.GridColumn_GC_ID').mask('9999999999', {reverse: true});
	};
	InitMask();
	var prm = Sys.WebForms.PageRequestManager.getInstance();
	if (prm != null) {
		prm.add_endRequest(function (sender, e) {
			if (sender._postBackSettings.panelsToUpdate != null) {
				InitMask();
			}
		});
	};
 });
