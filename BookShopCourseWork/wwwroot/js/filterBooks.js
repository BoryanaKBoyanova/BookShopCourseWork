$(document).ready(function() {
    $(".author-checkbox").click(function(event) {
        let checkbox = document.getElementById(event.target.id);
        const urlParams = new URLSearchParams(window.location.search);
        let authors = urlParams.get('authors');
        if(authors == null || authors == "")
        {
            urlParams.set("authors", checkbox.value);
        }
        else
        {
            authors = authors.split(",");
            if(checkbox.checked)
            {
                authors.push(checkbox.value);
            }
            else
            {
                authors.splice(authors.indexOf(checkbox.value), 1);
            }
            urlParams.set("authors", authors.join());
        }
        urlParams.set("page", 1);
        window.location.href = window.location.pathname + "?" + urlParams.toString();
    });
    $(".genre-checkbox").click(function(event) {
        let checkbox = document.getElementById(event.target.id);
        const urlParams = new URLSearchParams(window.location.search);
        let genres = urlParams.get('genres');
        if(genres == null || genres == "")
        {
            urlParams.set("genres", checkbox.value);
        }
        else
        {
            genres = genres.split(",");
            if(checkbox.checked)
            {
                genres.push(checkbox.value);
            }
            else
            {
                genres.splice(genres.indexOf(checkbox.value), 1);
            }
            urlParams.set("genres", genres.join());
        }
        urlParams.set("page", 1);
        window.location.href = window.location.pathname + "?" + urlParams.toString();
    });
    const urlParams = new URLSearchParams(window.location.search);
    let authors = urlParams.get('authors');
    let genres = urlParams.get('genres');
    if(authors != null && authors != "")
    {
        document.getElementById("authorsButton").classList.remove("collapsed");
        document.getElementById("collapseOne").classList.add("show");
        authors = authors.split(",");
        authors.forEach(aId => {
            document.getElementById(`author${aId}`).checked = true;
        });
    }
    if(genres != null && genres != "")
    {
        document.getElementById("genresButton").classList.remove("collapsed");
        document.getElementById("collapseTwo").classList.add("show");
        genres = genres.split(",");
        genres.forEach(gId => {
            document.getElementById(`genre${gId}`).checked = true;
        });
    }
});