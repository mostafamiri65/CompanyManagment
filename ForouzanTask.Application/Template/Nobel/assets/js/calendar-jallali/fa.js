!function(a){"function"==typeof define&&define.amd?define(["jquery","moment"],a):a(jQuery,moment)}(function(a,b){var c={1:"Ū±",2:"Ū²",3:"Ū³",4:"Ū´",5:"Ūµ",6:"Ū¶",7:"Ū·",8:"Ūø",9:"Ū¹",0:"Ū°"},d={"Ū±":"1","Ū²":"2","Ū³":"3","Ū´":"4","Ūµ":"5","Ū¶":"6","Ū·":"7","Ūø":"8","Ū¹":"9","Ū°":"0"};(b.defineLocale||b.lang).call(b,"fa",{months:"ŚŲ§Ł†ŁŪŁ‡_ŁŁŲ±ŪŁ‡_Ł…Ų§Ų±Ų³_Ų¢ŁŲ±ŪŁ„_Ł…Ł‡_ŚŁŲ¦Ł†_ŚŁŲ¦ŪŁ‡_Ų§ŁŲŖ_Ų³Ł¾ŲŖŲ§Ł…ŲØŲ±_Ų§Ś©ŲŖŲØŲ±_Ł†ŁŲ§Ł…ŲØŲ±_ŲÆŲ³Ų§Ł…ŲØŲ±".split("_"),monthsShort:"ŚŲ§Ł†ŁŪŁ‡_ŁŁŲ±ŪŁ‡_Ł…Ų§Ų±Ų³_Ų¢ŁŲ±ŪŁ„_Ł…Ł‡_ŚŁŲ¦Ł†_ŚŁŲ¦ŪŁ‡_Ų§ŁŲŖ_Ų³Ł¾ŲŖŲ§Ł…ŲØŲ±_Ų§Ś©ŲŖŲØŲ±_Ł†ŁŲ§Ł…ŲØŲ±_ŲÆŲ³Ų§Ł…ŲØŲ±".split("_"),weekdays:"ŪŚ©ā€Ų´Ł†ŲØŁ‡_ŲÆŁŲ´Ł†ŲØŁ‡_Ų³Ł‡ā€Ų´Ł†ŲØŁ‡_Ś†Ł‡Ų§Ų±Ų´Ł†ŲØŁ‡_Ł¾Ł†Ų¬ā€Ų´Ł†ŲØŁ‡_Ų¬Ł…Ų¹Ł‡_Ų´Ł†ŲØŁ‡".split("_"),weekdaysShort:"ŪŚ©ā€Ų´Ł†ŲØŁ‡_ŲÆŁŲ´Ł†ŲØŁ‡_Ų³Ł‡ā€Ų´Ł†ŲØŁ‡_Ś†Ł‡Ų§Ų±Ų´Ł†ŲØŁ‡_Ł¾Ł†Ų¬ā€Ų´Ł†ŲØŁ‡_Ų¬Ł…Ų¹Ł‡_Ų´Ł†ŲØŁ‡".split("_"),weekdaysMin:"Ū_ŲÆ_Ų³_Ś†_Ł¾_Ų¬_Ų´".split("_"),
longDateFormat:{LT:"HH:mm",LTS:"LT:ss",L:"YYYY/MM/DD",LL:"YYYY MMMM D",LLL:"YYYY MMMM D LT",LLLL:"dddd, YYYY MMMM D LT"},
meridiemParse:/Ł‚ŲØŁ„ Ų§Ų² ŲøŁ‡Ų±|ŲØŲ¹ŲÆ Ų§Ų² ŲøŁ‡Ų±/,isPM:function(a){return/ŲØŲ¹ŲÆ Ų§Ų² ŲøŁ‡Ų±/.test(a)},meridiem:function(a,b,c){return 12>a?"Ł‚ŲØŁ„ Ų§Ų² ŲøŁ‡Ų±":"ŲØŲ¹ŲÆ Ų§Ų² ŲøŁ‡Ų±"},calendar:{sameDay:"[Ų§Ł…Ų±ŁŲ² Ų³Ų§Ų¹ŲŖ] LT",nextDay:"[ŁŲ±ŲÆŲ§ Ų³Ų§Ų¹ŲŖ] LT",nextWeek:"dddd [Ų³Ų§Ų¹ŲŖ] LT",lastDay:"[ŲÆŪŲ±ŁŲ² Ų³Ų§Ų¹ŲŖ] LT",lastWeek:"dddd [Ł¾ŪŲ´] [Ų³Ų§Ų¹ŲŖ] LT",sameElse:"L"},relativeTime:{future:"ŲÆŲ± %s",past:"%s Ł¾ŪŲ´",s:"Ś†Ł†ŲÆŪŁ† Ų«Ų§Ł†ŪŁ‡",m:"ŪŚ© ŲÆŁ‚ŪŁ‚Ł‡",mm:"%d ŲÆŁ‚ŪŁ‚Ł‡",h:"ŪŚ© Ų³Ų§Ų¹ŲŖ",hh:"%d Ų³Ų§Ų¹ŲŖ",d:"ŪŚ© Ų±ŁŲ²",dd:"%d Ų±ŁŲ²",M:"ŪŚ© Ł…Ų§Ł‡",MM:"%d Ł…Ų§Ł‡",y:"ŪŚ© Ų³Ų§Ł„",yy:"%d Ų³Ų§Ł„"},preparse:function(a){return a.replace(/[Ū°-Ū¹]/g,function(a){return d[a]}).replace(/Ų/g,",")},postformat:function(a){return a.replace(/\d/g,function(a){return c[a]}).replace(/,/g,"Ų")},ordinalParse:/\d{1,2}Ł…/,ordinal:"%dŁ…",week:{dow:6,doy:12}}),a.fullCalendar.datepickerLang("fa","fa",{closeText:"ŲØŲ³ŲŖŁ†",prevText:"&#x3C;Ł‚ŲØŁ„Ū",nextText:"ŲØŲ¹ŲÆŪ&#x3E;",currentText:"Ų§Ł…Ų±ŁŲ²",monthNames:["ŚŲ§Ł†ŁŪŁ‡","ŁŁŲ±ŪŁ‡","Ł…Ų§Ų±Ų³","Ų¢ŁŲ±ŪŁ„","Ł…Ł‡","ŚŁŲ¦Ł†","ŚŁŲ¦ŪŁ‡","Ų§ŁŲŖ","Ų³Ł¾ŲŖŲ§Ł…ŲØŲ±","Ų§Ś©ŲŖŲØŲ±","Ł†ŁŲ§Ł…ŲØŲ±","ŲÆŲ³Ų§Ł…ŲØŲ±"],monthNamesShort:["1","2","3","4","5","6","7","8","9","10","11","12"],dayNames:["ŁŚ©Ų´Ł†ŲØŁ‡","ŲÆŁŲ´Ł†ŲØŁ‡","Ų³Ł‡ā€Ų´Ł†ŲØŁ‡","Ś†Ł‡Ų§Ų±Ų´Ł†ŲØŁ‡","Ł¾Ł†Ų¬Ų´Ł†ŲØŁ‡","Ų¬Ł…Ų¹Ł‡","Ų´Ł†ŲØŁ‡"],dayNamesShort:["Ū","ŲÆ","Ų³","Ś†","Ł¾","Ų¬","Ų´"],dayNamesMin:["Ū","ŲÆ","Ų³","Ś†","Ł¾","Ų¬","Ų´"],weekHeader:"Ł‡Ł",dateFormat:"yy/mm/dd",firstDay:6,isRTL:!0,showMonthAfterYear:!1,yearSuffix:""}),a.fullCalendar.lang("fa",{buttonText:{month:"Ł…Ų§Ł‡",week:"Ł‡ŁŲŖŁ‡",day:"Ų±ŁŲ²",list:"ŲØŲ±Ł†Ų§Ł…Ł‡"},allDayText:"ŲŖŁ…Ų§Ł… Ų±ŁŲ²",eventLimitText:function(a){return"ŲØŪŲ´ Ų§Ų² "+a}})});