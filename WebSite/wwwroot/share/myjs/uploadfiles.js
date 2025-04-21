$(function () {
    // Multiple images preview in browser
    var imagesPreview = function (input, placeToInsertImagePreview) {

        if (input.files) {
            var filesAmount = input.files.length;

            for (i = 0; i < filesAmount; i++) {
                var reader = new FileReader();

                reader.onload = function (event) {
                    //$($.parseHTML('<div>')).attr('class','col-lg-2').append();
                    $($.parseHTML('<img>')).attr('src', event.target.result).attr('style', 'width:20%;margin-right:2px;').attr('class', 'img-thumbnail').appendTo(placeToInsertImagePreview);
                    //$($.parseHTML('</div>')).append();
                }
                reader.readAsDataURL(input.files[i]);
            }
        }
    };

    $('#uploadPhotos').on('change', function () {
        imagesPreview(this, 'div.gallery');
    });
});
