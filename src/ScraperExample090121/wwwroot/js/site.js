function getSearchSiteAddr(searchHtml, searchEngine) {
    var searchArray;
    var el = document.createElement('html');
    el.innerHTML = searchHtml.searchEngineHTML;
    switch (searchEngine) {
        case 'google':
            searchArray = Array.from(el.querySelectorAll("div[id='main'] div a:not([class])")).map(x => x.outerHTML.split('&')[0]).filter(x => x.includes('q=http') || x.includes('q=https'));
            break;
        case 'bing':
            searchArray = Array.from(el.querySelectorAll("ol[id='b_results'] h2 a")).map(x => x.outerHTML).filter(x => x.includes('http') || x.includes('https'));
            break;
        case 'yahoo':
            searchArray = Array.from(el.querySelectorAll("div[id='results'] h3 a")).map(x => x.outerHTML.split('href=')[1]).filter(x => !x.includes('.search.yahoo.com'));
            break;
        default:
            searchArray = Array.from(el.querySelectorAll("div[id='main'] div a:not([class])")).map(x => x.outerHTML.split('&')[0]).filter(x => x.includes('q=http') || x.includes('q=https'));
            break;
    }
    return searchArray;
}

function getUrlIncedence(searchResult, url) {
    return searchResult.map((x, i) => x.includes(url) ? i + 1 : null).filter(x => x !== null)
}

function showResultsWrapper() {
    var element = document.getElementById('results-wrapper');
    element.style.display = 'block';
}

function showResults(urlIncidence) {
    var resultsElement = document.getElementById('results');
    resultsElement.innerHTML = urlIncidence.length === 0 ? "0" : urlIncidence.join(',');
}

function toggleCover() {
    var cover = document.getElementById('cover-identifier');
    var currentDisplay = cover.style.display;
    if (currentDisplay.toLowerCase() === 'none' || currentDisplay.toLowerCase() === '') {
        cover.style.display = 'block';
    }
    else {
        cover.style.display = 'none';
    }
}

$(document).ready(function () {
    document.getElementById('seoQuerySubmit').addEventListener('click', function () {
        toggleCover();
        var searchEngine = document.getElementById('SearchEngine').value;
        var terms = document.getElementById('Terms').value.replace(/ /g, '+');
        var searchUrl = document.getElementById('Url').value;
        var httpRequest = new XMLHttpRequest();
        var url = '/api/parser?terms=' + terms + '&searchEngine=' + searchEngine;
        httpRequest.open('GET', url);
        httpRequest.responseType = 'json';
        httpRequest.send(null);

        httpRequest.onreadystatechange = function () {
            if (httpRequest.readyState > 3) {
                var response = httpRequest.response;
                var searchResults = getSearchSiteAddr(response, searchEngine);
                if (searchResults.length === 0) return;
                showResultsWrapper();
                var urlIncidence = getUrlIncedence(searchResults, searchUrl);
                showResults(urlIncidence);
                toggleCover();
            }
        }
    })
})