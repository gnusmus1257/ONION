﻿var name = "";
var pageTrack;
var countTrack;


function getTracks(name, pageTrack, countTrack) {
    $.ajax({
        type: "GET",
        url: "/Home/GetTopTracks",
        data: { name: nameArtist, page: pageTrack, count: countTrack },
        dataType: "json",
        success: function (data) { loadTracks(data); }
    });
}

function loadTracks(data) {
    console.log(data)
    var container = $('div.tracks');
    container.html('');
    if (data !== -1) {
        for (var i = 0; i < data.length; i++) {
            var markup = ` 
                    <div class="col-md-10" style="width: 100%">
                         <button class="text-left btn btn-dafault " style="width: 100%; margin: 3px;">${data[i].name}</button>                        
                    </div>

            `;
            if (data[i].link !== null) {
                markup += `
                        <div class="col-md-2">
                                <a href=${data[i].link}><h5 class="text-center" style="cursor: pointer">Download<span  class="glyphicon glyphicon-floppy-disk"></span></h5></a>
                        </div>
                    `
            }
            container.append(markup);

        }
    }
}
$(document).ready(function () {
    nameArtist = document.getElementById('name').innerText;
    console.log(name);
    pageTrack = 1;


    $('.top_tracks').click(function () {
        pageTrack = 1;
        countTrack = 24;
        getTracks(name, pageTrack, countTrack);
        console.log(name);
    })

});
