# AbsoluteSpeed
東京ゲームショウ2018に出展したレースゲームの車の挙動スクリプトです。<br />
自分が担当した箇所のみのスクリプトとなっております。<br />
<br />
東京ゲームショウ2018への出展作品ということで、<br />
１プレイ(5分)の中でユーザが楽しめるような挙動を目指しました。<br />
具体的には、ユーザが短時間で車の操作感を習得でき、<br />
時間内にゴールできるレベルです。<br />
<br />
制作人数：5人<br />
制作期間：約2ヶ月<br />
制作時期：2018年6月~2018年9月<br />
担当した役割：<br />
プロジェクトマネージャ<br />
プログラマ(車の挙動)<br />
<br />

クラスの説明<br />
AirRide.cs			　　　->浮遊し、地面に沿って車体を傾ける処理。<br />
AirRideRay.cs		　　　->AirRideクラスで使用するレイをまとめたクラス。<br />
BodyFloat.cs			　　->地面から車体を浮遊させる処理を行うクラス。<br />
ConvertUnits.cs		　　->単位の変換をまとめたクラス。<br />
DirectionFix.cs	　　	->壁に衝突したときなどに方向修正を行うクラス。<br />
DirectionFixRay.cs		->DirectionFixで使用するレイをまとめたクラス。<br />
Engine.cs				->EngineRpmCalculatorクラスを使用し、各タイミングでの回転数を管理すクラス。<br />
EngineRpmCalculator.cs ->エンジンの回転数を算出するクラス。<br />
EngineSpeedCalc.cs 	->回転数を使用し速度に関する処理を行うクラス。<br />
GearData.cs			->Gearに関するデータをまとめたクラス。<br />
GearManager.cs		->ハンドルコントローラでギアの変更を行えるようにするクラス。<br />
GroundFollow.cs		->地面に沿って車体を傾ける処理クラス。<br />
IGearManager.cs		->ギア変更ができるインターフェース。<br />
LRRay.cs				->左右方向に出すレイのクラス。<br />
MacGearManager.cs	->mackintoshのキーボードでギアを変更できるようにするスクリプト。MonoBehaviour<br />
ObjectExtensions.cs	->Objectクラスの拡張メソッドをまとめるクラス。<br />
RayConfig.cs			->各Rayの情報を管理するクラス。Scriptable Object<br />
RayMethod.cs			->レイで使用するメソッドをまとめたクラス。<br />
RePlayCalc.cs			->RePlayに使用するクラス。<br />
RePlayer.cs			->プレイヤ以外でリプレイ処理を使用したい場合に使用するクラス。MonoBehaviour<br />
Recovery.cs			->数秒前の位置に車を戻す処理。<br />
RigidbodyCalc.cs		->Rigidbodyに関する計算処理のクラス。<br />
SpeedCalculator.cs		->速度の計算を行うクラス。<br />
SpeedLimitController.cs  ->最高速度を計算するクラス。<br />
SteeringScript.cs	 	->ハンドルに対する車の挙動の処理を行うクラス。<br />
VehicleCore.cs			->各クラスをnewして実際に使用するクラス。MonoBehaviour<br />
VehicleMove.cs		->車の動きの処理を行うクラス。<br />
VehicleSettings.cs		->車のパラメータをまとめたクラス。Scriptable Object<br />
WallHitCheck.cs		->壁に衝突したか判定するクラス。<br />
WheelData.cs			->タイヤに関するデータをまとめたクラス。<br />
WheelParams.cs		->タイヤに関するデータを調整する為のクラス。Scriptable Object<br />
WinGearManager.cs		->ギアの変更をWindowsようにキーバインドするクラス。MonoBehaviour<br />

作品動画(Youtube)<br />
https://studio.youtube.com/video/KQCAAe6EQVg/edit
<br />
ポートフォリオ(Google Drive)<br />
https://drive.google.com/drive/u/2/folders/1nO7zj7kwnLvtC9zZ8SAd1OVzKLSmO4wQ
