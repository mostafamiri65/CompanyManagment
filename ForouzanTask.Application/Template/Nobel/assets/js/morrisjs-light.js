// npm package: morris.js
// github link: https://github.com/morrisjs/morris.js

$(function() {
    'use strict';
  
  
    var colors = {
      primary        : "#6571ff",
      secondary      : "#7987a1",
      success        : "#05a34a",
      info           : "#66d1d1",
      warning        : "#fbbc06",
      danger         : "#ff3366",
      light          : "#e9ecef",
      dark           : "#060c17",
      muted          : "#7987a1",
      gridBorder     : "rgba(77, 138, 240, .15)",
      bodyColor      : "#000",
      cardBg         : "#fff"
    }
  
    var fontFamily = "'iransans', Helvetica, sans-serif"
  
  
  
    // Line Chart
    new Morris.Line({
      element: 'morrisLine',
      data: [
        { year: '1397', value: 2 },
        { year: '1398', value: 9 },
        { year: '1399', value: 5 },
        { year: '1400', value: 12 },
        { year: '1401', value: 5 }
      ],
      xkey: 'year',
      ykeys: ['value'],
      labels: ['Ł…Ł‚ŲÆŲ§Ų±'],
      lineColors: [colors.danger],
      gridLineColor: [colors.gridBorder],
      gridTextColor: colors.bodyColor,
      gridTextFamily: fontFamily,
    });
  
  
  
  
    // Area Chart
    Morris.Area({
      element: 'morrisArea',
      data: [
        { y: '1395', a: 100, b: 90 },
        { y: '1396', a: 75,  b: 65 },
        { y: '1397', a: 50,  b: 40 },
        { y: '1398', a: 75,  b: 65 },
        { y: '1399', a: 50,  b: 40 },
        { y: '1400', a: 75,  b: 65 },
        { y: '1401', a: 100, b: 90 }
      ],
      xkey: 'y',
      ykeys: ['a', 'b'],
      labels: ['Ų³Ų±Ū Ų§Ł„Ł', 'Ų³Ų±Ū ŲØ'],
      lineColors: [colors.danger, colors.info],
      fillOpacity: 0.1,
      gridLineColor: [colors.gridBorder],
      gridTextColor: colors.bodyColor,
      gridTextFamily: fontFamily,
    });
  
  
  
    // Bar Chart
    Morris.Bar({
      element: 'morrisBar',
      data: [
        { y: '1395', a: 100, b: 90 },
        { y: '1396', a: 75,  b: 65 },
        { y: '1397', a: 50,  b: 40 },
        { y: '1398', a: 75,  b: 65 },
        { y: '1399', a: 50,  b: 40 },
        { y: '1400', a: 75,  b: 65 },
        { y: '1401', a: 100, b: 90 }
      ],
      xkey: 'y',
      ykeys: ['a', 'b'],
      labels: ['Ų³Ų±Ū Ų§Ł„Ł', 'Ų³Ų±Ū ŲØ'],
      barColors: [colors.danger, colors.info],
      gridLineColor: [colors.gridBorder],
      gridTextColor: colors.bodyColor,
      gridTextFamily: fontFamily,
    });
  
  
  
    // Donut Chart
    Morris.Donut({
      element: 'morrisDonut',
      data: [
        {label: "ŁŲ±ŁŲ´ ŲÆŲ§Ł†Ł„ŁŲÆŪ", value: 12},
        {label: "ŁŲ±ŁŲ´ ŲÆŲ± ŁŲ±ŁŲ´ŚÆŲ§Ł‡", value: 30},
        {label: "ŁŲ±ŁŲ´ ŲØŲ§ Ų³ŁŲ§Ų±Ų´ Ų§ŪŁ…ŪŁ„Ū", value: 20}
      ],
      colors: [colors.danger, colors.info, colors.primary],
      labelColor: colors.bodyColor,
    });
  
  });