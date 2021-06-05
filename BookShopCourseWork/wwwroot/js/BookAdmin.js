function createBook()
{
    $.post( "/Book/CreateBook", { Title: $("#Title").val(), Description: $("#Description").val(), Pages: parseInt($("#Pages").val()), Price: parseFloat($("#Price").val()), PublishedOn: $("#PublishedOn").val(), PublisherName: $("#PublisherName").val(), ImgUrl: $("#ImgUrl").val(), FirstName: $("#FirstName").val(), LastName: $("#LastName").val(), GenreName: $("#GenreName").val()}, function( data ) {
        $( ".result" ).html( data );
      });
}