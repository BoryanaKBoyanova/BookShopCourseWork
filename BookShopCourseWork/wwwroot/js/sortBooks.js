function sortBooks()
{
    const urlParams = new URLSearchParams(window.location.search);
    urlParams.delete('order');
    urlParams.set("order", $("#orderBooks option:selected").val());
    window.location.href = window.location.pathname + "?" + urlParams.toString();
}
function setSelectedValue()
{
    const urlParams = new URLSearchParams(window.location.search);
    var select = document.getElementById('orderBooks');
    select.value = urlParams.get("order");
}