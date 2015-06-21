package code
{
	import code.*;
	
	import flash.display.MovieClip;
	import flash.display.SimpleButton;
	import flash.display.Sprite;
	
	import flash.events.Event;
	import flash.events.MouseEvent;
	import flash.events.EventDispatcher;
	import flash.events.KeyboardEvent;
	
	import flash.events.TouchEvent;
	import flash.events.TransformGestureEvent;
	import flash.ui.Multitouch;
	import flash.ui.MultitouchInputMode;
	
	import flash.utils.Timer;
	import flash.events.TimerEvent;
	
	
	public class seq2 extends MovieClip
	{
		public var btna:SimpleButton;
		public var vio:MovieClip;
		public var parentObj:Object; 
		
		
		Multitouch.inputMode = MultitouchInputMode.GESTURE; 
		
		//	if (master)	stage.addEventListener(TransformGestureEvent.GESTURE_PAN , onPan); 
		//if (!master) stage.addEventListener(MouseEvent.MOUSE_UP, ClickHandler);
		var timer:Timer = new Timer(1000, 1); //une fois apres 1000ms, faire l'init
		
		public function seq2()
		{
			addEventListener(Event.ADDED_TO_STAGE, stageAddHandler);
			super();			
		}
		
		
		public function stageAddHandler(e:Event):void
		{
			removeEventListener(Event.ADDED_TO_STAGE, stageAddHandler);
			stage.addEventListener (TransformGestureEvent.GESTURE_SWIPE, fl_SwipeHandler);
			if(this.parent != null)	parentObj = this.parent as Object;		
			parentObj._reseau.log("entre en seq2");	
			timer.addEventListener(TimerEvent.TIMER, init);
			timer.start();
			
		}
		public function init( event:Event ):void{
			btna.addEventListener(MouseEvent.MOUSE_DOWN, ClickHandler);
			timer.removeEventListener(TimerEvent.TIMER, init);
		}
		
		
		public function recoit(body: Array):void
		{
			if (body[1] == "alpha"){ btna.alpha=0.1;
			vio.visible = true;
			vio.play();
			}
		}
		
		
		
		public function ClickHandler(event:MouseEvent):void
		{	
			switch( event.target )
			{
				case btna :	
					//parentObj._reseau.log("clic btna");
					parentObj._reseau.sender("untruc");
					break;
			}
		}
		
		
		
		function fl_SwipeHandler(event:TransformGestureEvent):void
		{
			switch(event.offsetX)
			{
				// glissement vers la droite
				case 1:
				{
					// Début de votre code personnalisé
					// Cet exemple de code déplace l’objet sélectionné de 20 pixels vers la droite.
					btna.x += 20;
					// Fin de votre code personnalisé
					break;
				}
					// glissement vers la gauche
				case -1:
				{
					// Début de votre code personnalisé
					// Cet exemple de code déplace l’objet sélectionné de 20 pixels vers la gauche.
					btna.x -= 20;
					// Fin de votre code personnalisé
					break;
				}
			}
			
			switch(event.offsetY)
			{
				// glissement vers le bas
				case 1:
				{
					// Début de votre code personnalisé
					// Cet exemple de code déplace l’objet sélectionné de 20 pixels vers le bas.
					btna.y += 20;
					// Fin de votre code personnalisé
					break;
				}
					// glissement vers le haut
				case -1:
				{
					// Début de votre code personnalisé
					// Cet exemple de code déplace l’objet sélectionné de 20 pixels vers le haut.
					btna.y -= 20;
					// Fin de votre code personnalisé
					break;
				}
			}
		}
		
		
		
		
		
		
		public function RemoveFromStage():void {
			/*this.removeEventListener(Event.ENTER_FRAME , enterFrameHandler);
			this.stage.removeEventListener(MouseEvent.MOUSE_DOWN, mouseDownHandler);
			stage.removeEventListener(MouseEvent.MOUSE_UP  , mouseUpHandler );
			*/
			parent.removeChild(this);
		}
		
	}
}