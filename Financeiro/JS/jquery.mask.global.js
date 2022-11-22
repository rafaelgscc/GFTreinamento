var $j = jQuery.noConflict();

$j.jMaskGlobals = {
	maskElements: 'input,label,td,span,strong,div',
	byPassKeys: [9, 16, 17, 18, 36, 37, 38, 39, 40, 91],
	translation: {
		'!': { pattern: /^.$/},
		'I': { pattern: /^.$/, recursive: true },
		'A': { pattern: /^[^0-9]*$/, recursive: false },
		'B': { pattern: /^[^0-9]*$/, recursive: true },
		'9': { pattern: /[\d-]/},
		'0': { pattern: /[\d-]/, recursive: true },
		'#': { pattern: /[0-9 ]/},
		'&': { pattern: /[0-9 ]/, recursive: true },
		'a': { pattern: /[a-zA-Z]/},
		'b': { pattern: /[a-zA-Z]/, recursive: true },	
		'X': { pattern: /^[a-zA-Z0-9\u00C0-\u00FF!@#$%^&*(),.?":{}|<>-_ ]*$/ },
		'x': { pattern: /^[a-zA-Z0-9\u00C0-\u00FF!@#$%^&*(),.?":{}|<>-_ ]*$/, recursive: true },
		'M': { pattern: /^[a-zA-Z\u00C0-\u00FF!@#$%^&*(),.?":{}|<>-_ ]*$/, recursive: true },
	}
};
