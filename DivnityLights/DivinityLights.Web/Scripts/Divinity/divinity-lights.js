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
            // Word Rotate
            this.wordRotate();

            // Media Element
            this.mediaElement();
            // Owl Carousel
            this.owlCarousel();
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
        owlCarousel: function (options) {

            var total = $("div.owl-carousel:not(.manual)").length,
				count = 0;

            $("div.owl-carousel:not(.manual)").each(function () {

                var slider = $(this);

                var defaults = {
                    // Most important owl features
                    items: 5,
                    itemsCustom: false,
                    itemsDesktop: [1199, 4],
                    itemsDesktopSmall: [980, 3],
                    itemsTablet: [768, 2],
                    itemsTabletSmall: false,
                    itemsMobile: [479, 1],
                    singleItem: true,
                    itemsScaleUp: false,

                    //Basic Speeds
                    slideSpeed: 200,
                    paginationSpeed: 800,
                    rewindSpeed: 1000,

                    //Autoplay
                    autoPlay: true,
                    autoplayTimeout: 5000,
                    stopOnHover: false,

                    // Navigation
                    navigation: false,
                    navigationText: ["<i class=\"icon icon-chevron-left\"></i>", "<i class=\"icon icon-chevron-right\"></i>"],
                    rewindNav: true,
                    scrollPerPage: false,

                    //Pagination
                    pagination: true,
                    paginationNumbers: false,

                    // Responsive
                    responsive: true,
                    responsiveRefreshRate: 200,
                    responsiveBaseWidth: window,

                    // CSS Styles
                    baseClass: "owl-carousel",
                    theme: "owl-theme",

                    //Lazy load
                    lazyLoad: false,
                    lazyFollow: true,
                    lazyEffect: "fade",

                    //Auto height
                    autoHeight: false,

                    //JSON
                    jsonPath: false,
                    jsonSuccess: false,

                    //Mouse Events
                    dragBeforeAnimFinish: true,
                    mouseDrag: true,
                    touchDrag: true,

                    //Transitions
                    transitionStyle: false,

                    // Other
                    addClassActive: false,

                    //Callbacks
                    beforeUpdate: false,
                    afterUpdate: false,
                    beforeInit: false,
                    afterInit: false,
                    beforeMove: false,
                    afterMove: false,
                    afterAction: false,
                    startDragging: false,
                    afterLazyLoad: false
                }

                var config = $.extend({}, defaults, options, slider.data("plugin-options"));

                // Initialize Slider
                slider.owlCarousel(config).addClass("owl-carousel-init");

            });

        },
        mediaElement: function (options) {

            if (typeof (mejs) == "undefined") {
                return false;
            }

            $("video:not(.manual)").each(function () {

                var el = $(this);

                var defaults = {
                    defaultVideoWidth: 480,
                    defaultVideoHeight: 270,
                    videoWidth: -1,
                    videoHeight: -1,
                    audioWidth: 400,
                    audioHeight: 30,
                    startVolume: 0.8,
                    loop: false,
                    enableAutosize: true,
                    features: ['playpause', 'progress', 'current', 'duration', 'tracks', 'volume', 'fullscreen'],
                    alwaysShowControls: false,
                    iPadUseNativeControls: false,
                    iPhoneUseNativeControls: false,
                    AndroidUseNativeControls: false,
                    alwaysShowHours: false,
                    showTimecodeFrameCount: false,
                    framesPerSecond: 25,
                    enableKeyboard: true,
                    pauseOtherPlayers: true,
                    keyActions: []
                }

                var config = $.extend({}, defaults, options, el.data("plugin-options"));

                el.mediaelementplayer(config);

            });

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

        }
    }

    Core.initialize();

})();