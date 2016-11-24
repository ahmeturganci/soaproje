!function (a) { var b = function (c, d, e) { e && (e.stopPropagation(), e.preventDefault()), this.$element = a(c), this.$newElement = null, this.button = null, this.options = a.extend({}, a.fn.selectpicker.defaults, this.$element.data(), "object" == typeof d && d), null == this.options.title && (this.options.title = this.$element.attr("title")), this.val = b.prototype.val, this.render = b.prototype.render, this.init() }; b.prototype = { constructor: b, init: function (b) { var c = this; this.$element.hide(), this.multiple = this.$element.prop("multiple"); var d = void 0 !== this.$element.attr("class") ? this.$element.attr("class").split(/\s+/) : "", e = this.$element.attr("id"); this.$element.after(this.createView()), this.$newElement = this.$element.next(".select"); var f = this.$newElement, g = this.$newElement.find(".dropdown-menu"), h = this.$newElement.find(".dropdown-arrow"), j = (g.find("li > a"), f.addClass("open").find(".dropdown-menu li > a").outerHeight()); f.removeClass("open"); var k = g.find("li .divider").outerHeight(!0), l = this.$newElement.offset().top, n = 0, o = this.$newElement.outerHeight(); this.button = this.$newElement.find("> button"), void 0 !== e && (this.button.attr("id", e), a('label[for="' + e + '"]').click(function () { f.find("button#" + e).focus() })); for (var p = 0; p < d.length; p++) "selectpicker" != d[p] && this.$newElement.addClass(d[p]); this.multiple && this.$newElement.addClass("select-multiple"), this.button.addClass(this.options.style), g.addClass(this.options.menuStyle), h.addClass(function () { if (c.options.menuStyle) return c.options.menuStyle.replace("dropdown-", "dropdown-arrow-") }), this.checkDisabled(), this.checkTabIndex(), this.clickListener(); var q = parseInt(g.css("padding-top")) + parseInt(g.css("padding-bottom")) + parseInt(g.css("border-top-width")) + parseInt(g.css("border-bottom-width")); if ("auto" == this.options.size) { var r = debounce(function () { var b = l - a(window).scrollTop(), c = a(window).innerHeight(), d = q + parseInt(g.css("margin-top")) + parseInt(g.css("margin-bottom")) + 2, e = c - b - o - d; n = e, f.hasClass("dropup") && (n = b - d), n >= 300 && (n = 300), g.css({ "max-height": n + "px", "overflow-y": "auto", "min-height": 3 * j + "px" }) }, 50); a(window).on("scroll", r), a(window).on("resize", r), window.MutationObserver ? new MutationObserver(r).observe(this.$element.get(0), { childList: !0 }) : this.$element.bind("DOMNodeInserted", r) } else if (this.options.size && "auto" != this.options.size && g.find("li").length > this.options.size) { var s = g.find("li > *").filter(":not(.divider)").slice(0, this.options.size).last().parent().index(), t = g.find("li").slice(0, s + 1).find(".divider").length; n = j * this.options.size + t * k + q, g.css({ "max-height": n + "px", "overflow-y": "scroll" }) } window.MutationObserver ? new MutationObserver(a.proxy(this.reloadLi, this)).observe(this.$element.get(0), { childList: !0 }) : this.$element.bind("DOMNodeInserted", a.proxy(this.reloadLi, this)), this.render() }, createDropdown: function () { var b = "<div class='btn-group select'><button class='btn dropdown-toggle clearfix' data-toggle='dropdown'><span class='filter-option'></span>&nbsp;<span class='caret'></span></button><span class='dropdown-arrow'></span><ul class='dropdown-menu' role='menu'></ul></div>"; return a(b) }, createView: function () { var a = this.createDropdown(), b = this.createLi(); return a.find("ul").append(b), a }, reloadLi: function () { this.destroyLi(), $li = this.createLi(), this.$newElement.find("ul").append($li), this.render() }, destroyLi: function () { this.$newElement.find("li").remove() }, createLi: function () { var b = this, c = [], d = [], e = ""; if (this.$element.find("option").each(function () { c.push(a(this).text()) }), this.$element.find("option").each(function (c) { var e = void 0 !== a(this).attr("class") ? a(this).attr("class") : "", f = a(this).text(), g = void 0 !== a(this).data("subtext") ? '<small class="muted">' + a(this).data("subtext") + "</small>" : ""; if (f += g, a(this).parent().is("optgroup") && 1 != a(this).data("divider")) if (0 == a(this).index()) { var h = a(this).parent().attr("label"), i = void 0 !== a(this).parent().data("subtext") ? '<small class="muted">' + a(this).parent().data("subtext") + "</small>" : ""; h += i, 0 != a(this)[0].index ? d.push('<div class="divider"></div><dt>' + h + "</dt>" + b.createA(f, "opt " + e)) : d.push("<dt>" + h + "</dt>" + b.createA(f, "opt " + e)) } else d.push(b.createA(f, "opt " + e)); else 1 == a(this).data("divider") ? d.push('<div class="divider"></div>') : 1 == a(this).data("hidden") ? d.push("") : d.push(b.createA(f, e)) }), c.length > 0) for (var f = 0; f < c.length; f++) { this.$element.find("option").eq(f); e += "<li rel=" + f + ">" + d[f] + "</li>" } return 0 != this.$element.find("option:selected").length || b.options.title || this.$element.find("option").eq(0).prop("selected", !0).attr("selected", "selected"), a(e) }, createA: function (a, b) { return '<a tabindex="-1" href="#" class="' + b + '"><span class="">' + a + "</span></a>" }, render: function () { var b = this; if ("auto" == this.options.width) { var c = this.$newElement.find(".dropdown-menu").css("width"); this.$newElement.css("width", c) } else this.options.width && "auto" != this.options.width && this.$newElement.css("width", this.options.width); this.$element.find("option").each(function (c) { b.setDisabled(c, a(this).is(":disabled") || a(this).parent().is(":disabled")), b.setSelected(c, a(this).is(":selected")) }); var d = this.$element.find("option:selected").map(function (b, c) { return void 0 != a(this).attr("title") ? a(this).attr("title") : a(this).text() }).toArray(), e = d.join(", "); if (b.multiple && b.options.selectedTextFormat.indexOf("count") > -1) { var f = b.options.selectedTextFormat.split(">"); (f.length > 1 && d.length > f[1] || 1 == f.length && d.length >= 2) && (e = d.length + " of " + this.$element.find("option").length + " selected") } e || (e = void 0 != b.options.title ? b.options.title : b.options.noneSelectedText), this.$element.next(".select").find(".filter-option").html(e) }, setSelected: function (a, b) { b ? this.$newElement.find("li").eq(a).addClass("selected") : this.$newElement.find("li").eq(a).removeClass("selected") }, setDisabled: function (a, b) { b ? this.$newElement.find("li").eq(a).addClass("disabled") : this.$newElement.find("li").eq(a).removeClass("disabled") }, checkDisabled: function () { this.$element.is(":disabled") && (this.button.addClass("disabled"), this.button.click(function (a) { a.preventDefault() })) }, checkTabIndex: function () { if (this.$element.is("[tabindex]")) { var a = this.$element.attr("tabindex"); this.button.attr("tabindex", a) } }, clickListener: function () { var b = this; a("body").on("touchstart.dropdown", ".dropdown-menu", function (a) { a.stopPropagation() }), this.$newElement.on("click", "li a", function (c) { var d = a(this).parent().index(), e = a(this).parent(), f = e.parents(".select"); if (b.multiple && c.stopPropagation(), c.preventDefault(), f.prev("select").not(":disabled") && !a(this).parent().hasClass("disabled")) { if (b.multiple) { var g = f.prev("select").find("option").eq(d).prop("selected"); g ? f.prev("select").find("option").eq(d).removeAttr("selected") : f.prev("select").find("option").eq(d).prop("selected", !0).attr("selected", "selected") } else f.prev("select").find("option").removeAttr("selected"), f.prev("select").find("option").eq(d).prop("selected", !0).attr("selected", "selected"); f.find(".filter-option").html(e.text()), f.find("button").focus(), f.prev("select").trigger("change") } }), this.$newElement.on("click", "li.disabled a, li dt, li .divider", function (b) { b.preventDefault(), b.stopPropagation(), $select = a(this).parent().parents(".select"), $select.find("button").focus() }), this.$element.on("change", function (a) { b.render() }) }, val: function (a) { return void 0 != a ? (this.$element.val(a), this.$element.trigger("change"), this.$element) : this.$element.val() } }, a.fn.selectpicker = function (c, d) { var f, e = arguments, g = this.each(function () { var g = a(this), h = g.data("selectpicker"), i = "object" == typeof c && c; if (h) for (var j in c) h[j] = c[j]; else g.data("selectpicker", h = new b(this, i, d)); "string" == typeof c && (property = c, h[property] instanceof Function ? ([].shift.apply(e), f = h[property].apply(h, e)) : f = h[property]) }); return void 0 != f ? f : g }, a.fn.selectpicker.defaults = { style: null, size: "auto", title: null, selectedTextFormat: "values", noneSelectedText: "Nothing selected", width: null, menuStyle: null, toggleSize: null } }(window.jQuery);