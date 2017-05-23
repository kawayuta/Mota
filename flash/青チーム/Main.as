package  {
	
	import flash.display.MovieClip;
	import flash.media.Microphone;
	import flash.events.MouseEvent;
	import flash.media.SoundTransform;
	import flash.events.*;
	import flash.net.*;
	
	import flash.utils.*;
	
	
	public class Main extends MovieClip {
		
		//チーム1
		public var size:Number = 0;
		public var start_status:Boolean = false;
		
		public function Main() {

		start_button.addEventListener(MouseEvent.CLICK, clickHandler); 
			
			function clickHandler() {

				trace("satrt_click");
				start_status = true;
				removeChild(start_button);
				var request:URLRequest = new URLRequest();
		request.url = "http://192.168.11.3:3000/babies.json";
		request.contentType = "multipart/form-data";
		request.method = URLRequestMethod.POST;
						
		var urlVariables:URLVariables = new URLVariables();

		urlVariables.start_status = 'team_1'; // ココの1を2とかに変えて

		request.data = urlVariables;
		
		var contentTypeHeader:URLRequestHeader = new URLRequestHeader("Content-Type", "application/json");
		var acceptHeader:URLRequestHeader = new URLRequestHeader("Accept", "application/json");
		var formDataHeader:URLRequestHeader = new URLRequestHeader("Content-Type", "multipart/form-data");
		
		request.requestHeaders = [acceptHeader, formDataHeader];
		
		var postLoader = new URLLoader();
		postLoader.dataFormat = URLLoaderDataFormat.BINARY;
		
		try
		{
			trace(request.data);
			postLoader.load(request);
		}
		catch (error:Error)
		{
			trace("Unable to load post URL");
		}
		
			}
						
		var stream:URLStream;
		var uploadData:ByteArray;
					
		var mic = Microphone.getMicrophone();

		mic.setLoopBack(true);
		mic.soundTransform = new SoundTransform(0,0);

		this.addEventListener(Event.ENTER_FRAME,enterFrameHandler);
		trace(mic.activityLevel);
		function enterFrameHandler(event) {
			

		if (mic.activityLevel > 99 && start_status == true) {
			size += 0.005;
			if (balloon.scaleX > 5) {
				
			balloon.scaleX = 1;
			balloon.scaleY = 1;
			}
			
			balloon.scaleX += size;
			balloon.scaleY += size;
			var halfx:int = balloon.width / 2;
			var halfy:int = balloon.height / 2;
			trace(balloon.scaleX);
			trace(balloon.scaleY);
			balloon.x = (stage.stageWidth / 2) - halfx;
			balloon.y = (stage.stageHeight / 2) - halfy;
			
		var request:URLRequest = new URLRequest();
		request.url = "http://192.168.11.3:3000/babies.json";
		request.contentType = "multipart/form-data";
		request.method = URLRequestMethod.POST;
						
		var urlVariables:URLVariables = new URLVariables();

		urlVariables.nota_type = "type_1"; // ココの1を2とかに変えて

		request.data = urlVariables;
		
		var contentTypeHeader:URLRequestHeader = new URLRequestHeader("Content-Type", "application/json");
		var acceptHeader:URLRequestHeader = new URLRequestHeader("Accept", "application/json");
		var formDataHeader:URLRequestHeader = new URLRequestHeader("Content-Type", "multipart/form-data");
		
		request.requestHeaders = [acceptHeader, formDataHeader];
		
		var postLoader = new URLLoader();
		postLoader.dataFormat = URLLoaderDataFormat.BINARY;
		
		try
		{
			
			if(balloon.scaleX > 4) {
			trace(request.data);
			postLoader.load(request);
			}
			
		}
		catch (error:Error)
		{
			trace("Unable to load post URL");
		}


			 		
		}
		}

		 
		}

		}
	}
