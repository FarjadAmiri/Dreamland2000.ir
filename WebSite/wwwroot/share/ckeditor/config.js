CKEDITOR.editorConfig = function (config) {
    config.language = 'fa';    
    config.height = 300;
    config.filebrowserImageUploadUrl = '/ckeditor-upload';
    config.contentsCss = '/share/ckeditor/fonts.css';
    config.font_names = 'IRANSans;' + config.font_names;
};
