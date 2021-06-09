function changeStatusOrder(id)
{
    $.post( "../../Order/ChangeStatus", { OrderId: id, Status: $("#status").val()  }, function( data ) {
        location.reload();
      });
}
function getOrdersByStatus()
{
    window.location.href = "/Admin/ViewOrdersByStatus/" + $("#status").val();
}
function setSelectedValueStatus()
{
    const url = window.location.pathname.split('/');
    var select = document.getElementById('status');
    select.value = url[3];
    document.getElementById("title").innerText = $( "#status option:selected").text();
}
function findOrder()
{
    window.location.href = "/Admin/ViewAndEditOrder/"+ $("#id").val();
}