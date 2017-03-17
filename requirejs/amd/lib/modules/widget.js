define(['jquery','methods'], function($,methods) {
  
  // private var
  
 var s;
var privateVar=123;
  
  var jsonobj;
  
  
  NewsWidget = {
  settings: {
    numArticles: 5,
    articleList: $("#article-list"),
    moreButton: $("#load-button")
  },
  
  
  init: function() {
    s = this.settings;
    this.bindUIActions();
	//x=9;
  },
  
  bindUIActions: function() {
    s.moreButton.on("click", function() {
      NewsWidget.getMoreArticles(s.numArticles);
    });
  },
	  	  
	
  
  
   getMoreArticles: function(numToGet) {
    $(s.articleList).append('<br>hello');
    // using numToGet as param
  }
  
  
  ,getPrivateFN: function() { return privateVar;}
  
  
  ,getAjaxFN: function(arg) {   
  
  	var dataz = 'templateClientKey=mas&fis=';

	$.ajax({
		type : 'GET',
		url : arg,
		async : false,
		jsonpCallback : 'jsonCallback',
		contentType : "application/json",
		dataType : 'json',
		data : null, // multiple data sent using ajax
		success : function (json) {
			jsonobj = json;

			/* copied */
			//xvar MyPlayListTemplate
			// save in global ref var
			
			//xplaylistsObj = jsonobj;
			//xMyPlayListTemplate = jsonobj.MyPlayLists[0];
			//xconsole.log(MyPlayListTemplate);
			 //x loadContainer(MyPlayListTemplate, -1);

			/* end  */
			
			alert('loaded');
			console.log(json[0].playname);
			//jsonobj;

		},
		error : function (e) {
			console.log(e.message);
			//alert('fail');
			jsonobj = 'fail';
		}
	});
	  
  return jsonobj;
  
  } 
  
  }
  
  return NewsWidget;
});