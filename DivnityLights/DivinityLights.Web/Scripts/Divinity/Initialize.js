(function () {
    var Core = {
        initialized: false,

        initialize: function () {
            if (this.initialized) return;
            this.initialized = true;

            this.build();

        }, build: function () {

            // Animations
            this.animations();
            this.wordRotate();
            this.initializeMap();
        },
        animations: function () {

            // Animation Appear
            $("[data-appear-animation]").each(function () {

                var $this = $(this);

                $this.addClass("appear-animation");

                if (!$("html").hasClass("no-csstransitions") && $(window).width() > 767) {

                    $this.appear(function () {

                        var delay = ($this.attr("data-appear-animation-delay") ? $this.attr("data-appear-animation-delay") : 1);

                        if (delay > 1) $this.css("animation-delay", delay + "ms");
                        $this.addClass($this.attr("data-appear-animation"));

                        setTimeout(function () {
                            $this.addClass("appear-animation-visible");
                        }, delay);

                    }, { accX: 0, accY: -150 });

                } else {

                    $this.addClass("appear-animation-visible");

                }

            });

            // Animation Progress Bars
            $("[data-appear-progress-animation]").each(function () {

                var $this = $(this);

                $this.appear(function () {

                    var delay = ($this.attr("data-appear-animation-delay") ? $this.attr("data-appear-animation-delay") : 1);

                    if (delay > 1) $this.css("animation-delay", delay + "ms");
                    $this.addClass($this.attr("data-appear-animation"));

                    setTimeout(function () {

                        $this.animate({
                            width: $this.attr("data-appear-progress-animation")
                        }, 1500, "easeOutQuad", function () {
                            $this.find(".progress-bar-tooltip").animate({
                                opacity: 1
                            }, 500, "easeOutQuad");
                        });

                    }, delay);

                }, { accX: 0, accY: -50 });

            });

            // Count To
            $(".counters [data-to]").each(function () {

                var $this = $(this);

                $this.appear(function () {

                    $this.countTo({
                        onComplete: function () {
                            if ($this.data("append")) {
                                $this.html($this.html() + $this.data("append"));
                            }
                        }
                    });

                }, { accX: 0, accY: -150 });

            });

            /* Circular Bars - Knob */
            if (typeof ($.fn.knob) != "undefined") {
                $(".knob").knob({});
            }

        },

        wordRotate: function () {

            $(".word-rotate").each(function () {

                var $this = $(this),
					itemsWrapper = $(this).find(".word-rotate-items"),
					items = itemsWrapper.find("> span"),
					firstItem = items.eq(0),
					firstItemClone = firstItem.clone(),
					itemHeight = 0,
					currentItem = 1,
					currentTop = 0;

                itemHeight = firstItem.height();

                itemsWrapper.append(firstItemClone);

                $this
					.height(itemHeight)
					.addClass("active");

                setInterval(function () {

                    currentTop = (currentItem * itemHeight);

                    itemsWrapper.animate({
                        top: -(currentTop) + "px"
                    }, 300, "easeOutQuad", function () {

                        currentItem++;

                        if (currentItem > items.length) {

                            itemsWrapper.css("top", 0);
                            currentItem = 1;

                        }

                    });

                }, 2000);

            });

        },

        initializeMap: function () {
            var map_canvas = $("#map_canvas");
            if (map_canvas != undefined && map_canvas != null && map_canvas.length > 0) {
                var mapOptions = {
                    center: new google.maps.LatLng(28.356532, 77.262006),
                    zoom: 4,
                    mapTypeId: google.maps.MapTypeId.ROADMAP
                };
                var map = new google.maps.Map(document.getElementById("map_canvas"),
                  mapOptions);
                // create a marker  
                var latlng = new google.maps.LatLng(28.423601, 77.317689);
                var marker = new google.maps.Marker({
                    position: latlng,
                    map: map,
                    title: 'Sovitron, LED, Sector 53, Faridabad, Haryana 121005, India'
                });
            }
        },
    }

    Core.initialize();
})();

