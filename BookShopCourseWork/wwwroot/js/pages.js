function addPagination(pages)
{
    const urlParams = new URLSearchParams(window.location.search);
    const currentPage = urlParams.get('page');
    urlParams.delete('page');
    let paginationTop = document.getElementById("paginationBooksTop");
    let paginationBottom = document.getElementById("paginationBooksBottom");
    for(let i=1; i<=Math.ceil(pages/16.0); i++)
    {
        if(currentPage==i)
        {
            paginationTop.innerHTML += `<li class="page-item"><a class="page-link bg-primary text-secondary" href="/Book/ViewAllBooks?page=${i}&${urlParams.toString()}">${i}</a></li>`;
            paginationBottom.innerHTML += `<li class="page-item"><a class="page-link bg-primary text-secondary" href="/Book/ViewAllBooks?page=${i}&${urlParams.toString()}">${i}</a></li>`;
        }
        else
        {
            paginationTop.innerHTML += `<li class="page-item"><a class="page-link" href="/Book/ViewAllBooks?page=${i}&${urlParams.toString()}">${i}</a></li>`;
            paginationBottom.innerHTML += `<li class="page-item"><a class="page-link" href="/Book/ViewAllBooks?page=${i}&${urlParams.toString()}">${i}</a></li>`;
        }
    }
}