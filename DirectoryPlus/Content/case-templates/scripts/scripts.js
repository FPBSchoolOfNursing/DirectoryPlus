'use strict';
var TEMPLATE_VERSION = '0.98';
var BOOTSTRAP_VERSION = '3.3.7 CDN'; //They don't include it so I will. 
var MOBILE_MODE_SCREENWIDTH = 767; //When the responsive structure changes the menu to mobile mode

$(function(){	
	//if scrolling past 100px down fade in the button that allows the user to scroll back up
	$(window).scroll(function () {
		if ($(this).scrollTop() > 100) {
			$('#back-top').fadeIn();
		} else {
			$('#back-top').fadeOut();
		}
	});
	
	//this is the button that fades in past 100px, it allows the screen to scroll back up to the top of the page.
	$('#back-top').click(function (e) {
		e.preventDefault();
		$('body,html').animate({
			scrollTop: 0
		}, 300);
		//return false;
	});
	
	// Global links toggle
	$('#global-menu-toggle').click(function(e) {
		e.preventDefault();
		$('#global-menu').slideToggle('fast');
		$(this).toggleClass('active');
		//return false;
	});	
	
	doSticky(); //setup nav stickieness.
	doitnow(); //doing it :)
	bootstrapColumnChecker(); //check our page for bootstrap column width complience. 
	
	//getRaveData(); //Get alerts from the RAVE Warning System
});

var stickycssclass = "navbar-fixed-top-override"; //Needs to stay override for centering.
function doSticky() {
	/* Sticky menu hack for boot strap */
	var $nav = $("nav.navbar, ul.nav-tabs.tabs-stick-top"); //cache the nav bar, or tabs. This might cause issues if someone does	
	if($nav.length <= 0) { return; } //if there is no NAV return 
	var Yoffset = $nav.offset().top; //get the current y offset. note in mobile modes the menu should not stick
	var contwidth = getContainerWidth(); //get the width of the content container
	var isStuck = false;
	
	function getContainerWidth() {		
		return $("main").width();
	}	
	
	function stickyscroll()
	{	
		/*jshint validthis:true */
		if($(window).width() >= MOBILE_MODE_SCREENWIDTH) { //stick in desktop modes only						
			if($(window).scrollTop() > Yoffset) { //if the window top is larger then the nav top offset,	
				if(!this.isStuck) {				//added a flag to prevent the next stuff from being called on every scroll.	
					this.isStuck = true;
					$("footer").css("padding-bottom", "70px"); //Fixing issue 127. Height of the nav bar + line height
					$nav.addClass(stickycssclass); 	//apply position fixed, top 0 and zindex of 1030				
					if(contwidth !== $nav.width())
					{						//if the container and the nav are not same
						$nav.width(contwidth);		/*fix the nav to fit the container, This will prevent the nav from expanding to 100% on stick*/
					}
				}
			}
			else if(this.isStuck) {					
				this.isStuck = false;		
				$("footer").css("padding-bottom", "none"); //Remove the 'fix' 
				$nav.removeClass(stickycssclass); //apply position fixed, top 0 and zindex of 1030	
			}			
		}		
	}	
	document.onscroll = stickyscroll; //attach the sticky event
		
	//By wrapping the nav in a div.container element bootstrap handles the resize. 
	$(window).resize(function () {		 
		contwidth = getContainerWidth();
		if(contwidth !== $nav.width())	
		{				
			$nav.width(contwidth);	//resize the nav bar 
		}
		//Fixes issue 74, on resize to mobile mode if the menu was 'stuck' remove stickiness 
		if($(window).width() < MOBILE_MODE_SCREENWIDTH && $nav.hasClass(stickycssclass)) //stick in desktop modes only
		{			
			$nav.removeClass(stickycssclass); //remove the fixed position.
			isStuck = false;
		}
		//Fix for issue #78, on resize from mobile to desktop. if scrolled down menu should appear.
		if($(window).width() >= MOBILE_MODE_SCREENWIDTH && !$nav.hasClass(stickycssclass) && $(window).scrollTop() > Yoffset)
		{			
			$nav.addClass(stickycssclass);
			isStuck = true;
		}
		
		/*
		if you want to make mobile menu sticky you have to recalc the yoffset because of the header size change.
		if(contwidth < 768)
		{
			Yoffset = $nav.offset().top;
		}
		*/			
	});	
}
function doitnow() 
{	
	var eg = 0;
	var $body = $("body, a");
	$body.click(function (e) {
		if(e.clientX < 3 && e.clientY < 3){ //click the upper left 2x2 pixel box 10x, 11 turns it off.
			eg++;
			if(eg === 10) 
			{ 
				console.error("needle mode.... activate.");				
				/*$body.css("cursor", "url('/case-templates/images/curser.cur'), auto");*/
				$body.css("cursor", "url('https://case.edu/nursing/media/nursing/layout-assets/curser.cur'), auto");
			}
			else if(eg === 11)
			{
				console.error("needle mode.... deactivate.");
				eg = 0;
				$body.css("cursor", "auto");
			}			
		}		
	});
}
/*
	Bootstrap column checker 
	This will look at the main content row and check for inconsistencies in the column widths. 
	7/14/2015 - Initial.
	7/15/2015 - Added the ability to check all level 1 rows. Note rows in rows are not checked yet. 
				Cleaned up some code. There were some definite logic errors introduced. :)
	
	Note I left checking all of the main > .row for now. 
*/
function bootstrapColumnChecker()
{	
	$("main > .row").each(function (index,row) { //foreach column
		var xssum = 0,
			smsum = 0,
			mdsum = 0,
			lgsum = 0;	//our sums for the col widths
		var columns = $(row).children(); //get the columns for each row. 
		
		$(columns).each(function(i,v) {			
			var columnwidth = $(v).attr('class');	//get the class col-sm-xx 
						
			var colvalue = columnwidth.substring(7);	//get the width of the column 
			var coltype = columnwidth.substring(4, 6);	//get the type of column 		
			var t = parseInt(colvalue); //parse the value for summing
									
			switch(coltype) //based on the column type add our sums up.
			{
				case "sm":					
					smsum += t;
					break;
				case "md":					
					mdsum += t;
					break;
				case "lg":					
					lgsum += t;
					break;
				case "xs":					
					xssum += t;
					break;				
			}
		}); //each column	
		/*if the sums of the colums are greater than 0 (there are no columsn of type) and do not equal 12. There is a mismatch and needs to be corrected */
		if(xssum > 0 && xssum !== 12) {
			console.error("Your main content extra small columns do not sum to 12, please check your column breakpoints.");
		}
		if(smsum > 0 && smsum !== 12) {
			console.error("Your main content small columns do not sum to 12, please check your column breakpoints.");
		}
		if(mdsum > 0 && mdsum !== 12) {
			console.error("Your main content medium columns do not sum to 12, please check your column breakpoints.");
		}
		if(lgsum > 0 && lgsum !== 12) {
			console.error("Your main content large columns do not sum to 12, please check your column breakpoints.");
		}		
	});	//each row
}

function isDesktopView()
{
	return ($(window).width() > MOBILE_MODE_SCREENWIDTH );
}

function isMobileView()
{
	return ($(window).width() <= MOBILE_MODE_SCREENWIDTH );
}