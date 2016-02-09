/*
Name: 			View - Home
Written by: 	Okler Themes - (http://www.okler.net)
Version: 		2.0
*/
var sliderApi;
(function() {

	"use strict";

	var Product = {

		initialized: false,

		initialize: function() {

			if (this.initialized) return;
			this.initialized = true;

			this.build();
		},

		build: function(options) {

			// Revolution Slider Initialize
			$("#revolutionSlider").each(function() {

				var slider = $(this);

				var defaults = {
					delay: 9000,
					startheight: 495,
					startwidth: 960,

					hideThumbs: 10,

					thumbWidth: 100,
					thumbHeight: 50,
					thumbAmount: 5,

					navigationType: "both",
					navigationArrows: "verticalcentered",
					navigationStyle: "round",
					navigationVOffset: -30,
					soloArrowLeftHOffset: 60,
					soloArrowRightHOffset: 60,

					touchenabled: "on",
					onHoverStop: "on",

					navOffsetHorizontal: 0,
					navOffsetVertical: 20,

					stopAtSlide: 0,
					stopAfterLoops: -1,

					shadow: 0,
					fullWidth: "on",
					videoJsPath: "vendor/rs-plugin/videojs/"
				}

				var config = $.extend({}, defaults, options, slider.data("plugin-options"));

				// Initialize Slider
				sliderApi = slider.revolution(config).addClass("slider-init");

				// Set Play Button to Visible
				sliderApi.bind("revolution.slide.onloaded ",function (e,data) {
					$(".home-player").addClass("visible");
				});

			});


		},

	};

	Product.initialize();

})();