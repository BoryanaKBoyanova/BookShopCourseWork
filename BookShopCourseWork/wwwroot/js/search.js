function searchForBooks()
{
    const urlParams = new URLSearchParams(window.location.search);
    urlParams.delete("page");
    urlParams.set("search", $("#search").val());
    window.location.href = `/Book/ViewAllBooks?page=1&${urlParams.toString()}`;
}
function setSearchValue()
{
    const urlParams = new URLSearchParams(window.location.search);
    var search = document.getElementById('search');
    search.value = urlParams.get("search");
}