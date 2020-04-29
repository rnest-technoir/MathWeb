
let CalculateFunction = (function () {

    let _map = new WeakMap();
    let _privates = { wrapper: null, circlesWrapper: null, xScale: null, yScale: null, svg: null, svgHandler: null, points: null, margin: 0, poffset: 0 }

    function _ctor(points) {

        _map.set(this, _privates);
        _map.get(this).points = points;
    }

    _ctor.prototype.setPoints = function (points) {
        _map.get(this).points = points;
    }

    _ctor.prototype.clearAll = function () {
       
        d3.selectAll('circle.plot-points').remove();
        d3.selectAll('path.plot-path').remove();
        d3.selectAll('g#circles').remove();
        _map.get(this).points = [];
    }

    _ctor.prototype.setDefaults = function () {

        let points = _map.get(this).points;
        let pOffset = _map.get(this).poffset;
        let width = _map.get(this).width;
        let height = _map.get(this).height;

        let pxMax = d3.max(points, function (item) { return item.px; });
        let pxMin = d3.min(points, function (item) { return item.px; });
        
        let pyMax = d3.max(points, function (item) { return item.py; });
        let pyMin = d3.min(points, function (item) { return item.py; });

        let xScale = d3.scaleLinear().domain([pxMin - pOffset, pxMax + pOffset]).range([0, width]);
        let yScale = d3.scaleLinear().domain([pyMin - pOffset, pyMax + pOffset]).range([height, 0]);

        _map.get(this).xScale = xScale;
        _map.get(this).yScale = yScale;

    }

    _ctor.prototype.drawLayout = function () {

        let margin = _map.get(this).margin;
        let svg = _map.get(this).svg;
        let width = _map.get(this).width;
        let height = _map.get(this).height;

        svg.attr('id', 'layout')
            .attr('width', width + margin)
            .attr('height', height + margin);

        let wrapper = svg.append('g')
            .attr('id', 'wrapper')
            .attr('transform', 'translate(' + (width) + ', 0)');

        _map.get(this).wrapper = wrapper;

        let thickPadding = 10;

        let left = wrapper.append('g')
            .attr('id', 'left')
            .attr('width', width)
            .attr('height', height)
            .call(d3.axisLeft(_map.get(this).yScale)
                .ticks(15)
                .tickSize(width)
                .tickPadding(thickPadding))
            .transition().duration(800);

        wrapper.append('g')
            .attr('id', 'bottom')
            .attr('transform', 'translate(' + (-width) + ', 0)')
            .call(d3.axisBottom(_map.get(this).xScale)
                .ticks(15)
                .tickSize(width)
                .tickPadding(thickPadding))
            .transition().duration(800);

    }

    _ctor.prototype.clearLayout = function () {

        d3.select('g#wrapper').remove();

    }

    _ctor.prototype.drawFunction = function () {

        let points = _map.get(this).points;
        let xScale = _map.get(this).xScale;
        let yScale = _map.get(this).yScale;

        let svg = _map.get(this).svg;

        let circlesWrapper = svg.append('g')
            .attr('id', 'circles')
            .attr('transform', 'translate(' + 0 + ', 0)');

        circlesWrapper.selectAll('circles')
            .data(points)
            .enter()
            .append('circle')
            .attr('r', 5)
            .attr('class', 'plot-points')
            .attr('cx', function (d) { return xScale(d.px); })
            .attr('cy', function (d) { return yScale(d.py); })
            .transition().duration(1000).attr('r', 3).attr('fill', 'steelblue');

        circlesWrapper.selectAll('circles.plot-points')
            .append('text')
            .text(function (d) { return d.px + '/' + d.py });
            


        _map.get(this).circlesWrapper = circlesWrapper;

    }

    _ctor.prototype.drawPlotLines = function () {

        let points = _map.get(this).points;

        let xScale = _map.get(this).xScale;
        let yScale = _map.get(this).yScale;
        let wrapper = _map.get(this).wrapper;
        let width = _map.get(this).width;

        let area = d3.line()
            .x(function (d) { return xScale(d.px); })
            .y(function (d) { return yScale(d.py); });

        wrapper.append('path')
            .attr('d', area(points))
            .attr('class', 'plot-path')
            .attr('fill', 'none')
            .attr('stroke', 'steelblue')
            .attr('transform', 'translate(' + (-width) + ', 0)')
            .transition().duration(1000).attr('stroke', 'lightsteelblue');

    }

    _ctor.prototype.drawXY = function () {

        d3.selectAll("g.tick text")
            .filter(function () {

                if (d3.select(this).text() == 0) {
                    let parent = this.parentNode;
                    let line = parent.childNodes[0];
                    d3.select(line).attr('class', 'redline');
                    d3.select(line)
                        .style('stroke', 'red')
                        .style('stroke-width', '4px')
                        .transition().duration(1000)
                        .style('stroke', 'rgba(112, 28, 28, 0.35)')
                        .style('stroke-width', '2px');
                }
                
                return d3.select(this).text() == 0
            })
            .attr("fill", "red");

    }

    _ctor.prototype.drawPlot = function (svgHandler, width, height, drawLines) {

        let svg = d3.select(svgHandler).append('svg')
            .attr('viewBox', '0 0 ' + width + ' ' + height)
            .attr('width', width)
            .attr('height', height);

        _map.get(this).svg = svg;
        _map.get(this).poffset = 50;
        _map.get(this).margin = 50;
        _map.get(this).width = width;
        _map.get(this).height = height;

        this.setDefaults();
        this.drawLayout();
        this.drawFunction();

        if (drawLines) {
            this.drawPlotLines();
        }

        this.drawXY();
        
    }


    return _ctor;

}());