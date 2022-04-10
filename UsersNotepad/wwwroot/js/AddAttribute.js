$('#AddAttributes').click(function () {
    var newAttribute = "<div class='row mb-2'>"
        + "<div class='col'><input type='text' class='form-control AttributeName' placeholder='Nazwa atrybutu' required></input></div>"
        + "<div class='col'><input type='text' class='form-control AttributeValue' placeholder='Wartość atrybutu' required></input></div>"
        + "</div>";

    $('.attributes').append(newAttribute);
});