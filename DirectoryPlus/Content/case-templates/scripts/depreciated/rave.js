/* This was scraped from the t4-template 1/9/15 
* On page load it looks at the rave server, if there is data present in the callback it will add a 
* div to the top of the page with header, status,  event, headline, description, instruction, note, web, and contact info.
*
*/

/* Rave */

function raveCallback(data) {
	if (data === undefined)	
		console.log("Currently is no RAVE warnings");	
    if (data !== undefined) {
        console.warn("A RAVE system warning has been issued. Hide yo' kids. Hide yo' wife",  data);
        var div = document.createElement('div');
        div.style.backgroundColor = data.bgcolor;
        div.style.color = data.fgcolor;
        div.style.width = '98%';
        div.style.padding = '5px 1% 5px 1%';
        var html = '<div style="margin:auto; max-width:1000px; width:100%;text-align:center;">';
            html += (data.header) ? '<div>' + data.header +'</div>' : '';
            html += (data.status) ? '<div>' + data.status + '</div>' : '';
            html += (data.event) ? '<div>' + data.event + '</div>' : '';
            html += (data.headline) ? '<div>' + data.headline + '</div>' : '';
            html += (data.description) ? '<div>' + data.description + '</div>' : '';
            html += (data.instruction) ? '<div>' + data.instruction + '</div>' : '';
            html += (data.note) ? '<div>' + data.note + '</div>' : '';
            html += (data.web) ? '<div>' + data.web + '</div>' : '';
            html += (data.contact) ? '<div>' + data.contact + '</div>' : '';
        html += '</div>';
        div.innerHTML = html;
        document.body.insertBefore(div, document.body.firstChild);
    }
}

$.ajax({
  dataType: "jsonp", 
  url: "//webapps.case.edu/t4/rave/jsonp.pl?callback=raveCallback",
  success: function () { console.log("Rave Callback Successful"); },
	error:  function(xhr, textStatus, errorThrown) { console.error("Rave Callback Unsuccessful", xhr, textStatus, errorThrown); } 
});

/* End Rave */

 /* https://launchpad.case.edu/gadgets/rave.html?_gid=rave&_isMobile=true
 function rave(json) {
      var html = new Array();
	  console.log("HERE2", json);
      if (json==null) {
        html[html.length] = "<div id=\"status_normal\">Status: Normal</div>";
      } else {
        if (json.fgcolor != null) {
          document.getElementById('case_rave_div').style.color = json.fgcolor;
        }
        if (json.bgcolor != null) {
          document.getElementById('case_rave_div').style.backgroundColor = json.bgcolor;
        }
        if (json.header != null) {
          html[html.length] = "<div id='case_rave_div_header' class='PortletText0'>" + json.header + "</div>";
        }
        if (json.status != null) {
          html[html.length] = "<div id='case_rave_div_status'>" + json.status + "</div>";
        }
        if (json.event != null) {
          html[html.length] = "<div id='case_rave_div_event'>" + json.event + "</div>";
        }
        if (json.headline != null) {
          html[html.length] = "<div id='case_rave_div_headline'>" + json.headline + "</div>";
        }
        if (json.description != null) {
          html[html.length] = "<div id='case_rave_div_description'>" + json.description + "</div>";
        }
        if (json.instruction != null) {
          html[html.length] = "<div id='case_rave_div_instruction'>" + json.instruction + "</div>";
        }
        if (json.note != null) {
          html[html.length] = "<div id='case_rave_div_note'>" + json.note + "</div>";
        }
        if (json.web != null) {
          html[html.length] = "<div id='case_rave_div_web'>" + json.web + "</div>";
        }
        if (json.contact != null) {
          html[html.length] = "<div id='case_rave_div_contact'>" + json.contact + "</div>";
        }
      }
      // Display HTML string in <div>
      document.getElementById('case_rave_div').innerHTML = html.join("");

     
    }

    function display() {
      var rand = Math.ceil(Math.random()*1000000)
	   console.log("HERE");
      var myscript = document.createElement('script');
	  console.log( 'https://www.case.edu/cgi-bin/rave/json/rave.pl?callback=rave&webstartcache=' + rand );
      myscript.setAttribute('src', 'https://www.case.edu/cgi-bin/rave/json/rave.pl?callback=rave&webstartcache=' + rand);
      myscript.setAttribute('type', 'text/javascript');
      document.body.appendChild(myscript);
  
    }

    display();




function getRaveData() {
	var rand = Math.ceil(Math.random()*1000000)

	$.ajax({
	  dataType: "jsonp", 
	  url: "//www.case.edu/cgi-bin/rave/json/rave.pl?callback=rave&webstartcache=" + rand,
	  success: function () { console.log("Rave Callback Successful"); },
	  error:  function(xhr, textStatus, errorThrown) { console.error("Rave Callback Unsuccessful", xhr, textStatus, errorThrown); }  

	});	
}

function rave(json)
{
	console.log(json);
}
*/
