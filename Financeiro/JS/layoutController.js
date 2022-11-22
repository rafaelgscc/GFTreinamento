var LayoutController = LayoutController || (function () {
	var container;
	var header;
	var footer;
	var sidebar;
	var overlay;
	var clientState;

	var sidebarFull = true;
	var headerFixed = true;
	var footerFixed = true;

	var hasSidebar = false;
	var hasHeader = false;
	var hasFooter = false;

	var isSidebarAutoOpen = true;

	var $j = jQuery.noConflict();

	function isSmallScreen() {
		return !(window.matchMedia('(min-width: 768px)').matches);
	}

	function fixAjaxLoadingWidth(sender, args) {
		$j(args._loadingElement).width(container.width());
		$j(args._loadingElement).css('margin-left', container.css('margin-left'));
    }

	function adjustOverlay() {
		if (!sidebarFull) {
			var h = 0;
			if (hasHeader && headerFixed) {
				var hh = header.height();
				overlay.css('margin-top', hh);
				h += hh;
			}
			if (hasFooter && footerFixed) {
				var fh = footer.height();
				overlay.css('margin-bottom', fh);
				h += fh;
			}
			overlay.css('height', 'calc(100vh - ' + (h) + 'px');
		} else {
			overlay.css('height', '100vh');
		}
	}

	function toggleSidebar() {
		if (!sidebar) return;

		if (isSidebarAutoOpen) {
			if (isSmallScreen()) {
				if (sidebar.hasClass('closed')) sidebar.removeClass('closed');
				sidebar.toggleClass('opened');
				
			} else {
				if (sidebar.hasClass('opened')) sidebar.removeClass('opened');
				sidebar.toggleClass('closed');
			}
		} else {
			sidebar.toggleClass('opened');
		}

		if (sidebar.hasClass("opened")) {
			clientState.val("true");
			setCookie('SideBarCookie', 'true', 365);
		} else if (sidebar.hasClass("closed")) {
			setCookie('SideBarCookie', 'false', 365);
			clientState.val("false");
		} else {
			setCookie('SideBarCookie', '', 365);
			clientState.val("");
		}

		if (container && ((!isSidebarAutoOpen && !sidebar.hasClass("opened")) || sidebar.hasClass("closed"))) container.addClass('gvFull'); else if (container) container.removeClass('gvFull');

		if (header && sidebarFull && ((!isSidebarAutoOpen && !sidebar.hasClass("opened")) || sidebar.hasClass("closed"))) header.addClass('gvFull'); else if (header) header.removeClass('gvFull');

		if (footer && sidebarFull && ((!isSidebarAutoOpen && !sidebar.hasClass("opened")) || sidebar.hasClass("closed"))) footer.addClass('gvFull'); else if (footer) footer.removeClass('gvFull');

		if (sidebar.hasClass('opened')) {
			adjustOverlay();
			overlay.addClass('active');
		} else {
			overlay.removeClass('active');
		}

	}

	function registerSidebar(options) {
		if (options.sidebar) {
			container = $j(options.container);
			sidebar = $j(options.sidebar);
			clientState = $j(options.clientState);
			hasSidebar = sidebar.length;
			sidebarFull = (options.mode === 'full');
			isSidebarAutoOpen = (options.autoOpen === true);

			if (hasSidebar) {

				overlay = $j("#gvLayoutOverlay");
				if (overlay.length === 0) {
					overlay = $j('<div id="gvLayoutOverlay"></div>');
					overlay.addClass('gvOverlay');
					$j('body form').append(overlay);
				}

				sidebar.mCustomScrollbar({
					theme: 'minimal'
				});

				overlay.unbind('click', toggleSidebar);
				overlay.bind('click', toggleSidebar);
			}
		}
	}

	function registerHeader(options) {
		if (options.header) {
			container = $j(options.container);
			header = $j(options.header);
			hasHeader = header.length;
			if (hasHeader) {
				headerFixed = (options.position === 'fixed');
			}
		}
	}

	function registerFooter(options) {
		if (options.footer) {
			container = $j(options.container);
			footer = $j(options.footer);
			hasFooter = footer.length;
			if (hasFooter) {
				footerFixed = (options.position === 'fixed');
			}
		}
	}

	return {
		toggle: function () {
			toggleSidebar();
		},
		registerSidebar: function (options) {
			registerSidebar(options);
		},
		registerHeader: function (options) {
			registerHeader(options);
		},
		registerFooter: function (options) {
			registerFooter(options);
		},
		fixAjaxLoadingWidth: function (sender, args) {
			fixAjaxLoadingWidth(sender, args);
		}
	};

})();
