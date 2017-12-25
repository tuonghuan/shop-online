/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    
    config.syntaxhighlight_lang = 'csharp';
    config.syntaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = '/Assets/Admin/js/Plugins/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/Assets/Admin/js/Plugins/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/Assets/Admin/js/Plugins/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/Assets/Admin/js/Plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserImageUploadUrl = '/Data';
    config.filebrowserFlashUploadUrl = '/Assets/Admin/js/Plugins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
    CKFinder.setupCKEditor(null, '/Assets/Admin/js/Plugins/ckfinder/');

};
