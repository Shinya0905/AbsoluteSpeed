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
AirRide.cs<br />->浮遊し、地面に沿って車体を傾ける処理。<br /><br />
AirRideRay.cs<br />->AirRideクラスで使用するレイをまとめたクラス。<br /><br />
BodyFloat.cs<br />->地面から車体を浮遊させる処理を行うクラス。<br /><br />
ConvertUnits.cs<br />->単位の変換をまとめたクラス。<br /><br />
DirectionFix.cs<br />->壁に衝突したときなどに方向修正を行うクラス。<br /><br />
DirectionFixRay.cs<br />->DirectionFixで使用するレイをまとめたクラス。<br /><br />
Engine.cs<br />->EngineRpmCalculatorクラスを使用し、各タイミングでの回転数を管理すクラス。<br /><br />
EngineRpmCalculator.cs<br />->エンジンの回転数を算出するクラス。<br /><br />
EngineSpeedCalc.cs<br />->回転数を使用し速度に関する処理を行うクラス。<br /><br />
GearData.cs<br />->Gearに関するデータをまとめたクラス。<br /><br />
GearManager.cs<br />->ハンドルコントローラでギアの変更を行えるようにするクラス。<br /><br />
GroundFollow.cs<br />->地面に沿って車体を傾ける処理クラス。<br /><br />
IGearManager.cs<br />->ギア変更ができるインターフェース。<br /><br />
LRRay.cs<br />->左右方向に出すレイのクラス。<br /><br />
MacGearManager.cs<br />->mackintoshのキーボードでギアを変更できるようにするスクリプト。MonoBehaviour<br /><br />
ObjectExtensions.cs<br />->Objectクラスの拡張メソッドをまとめるクラス。<br /><br />
RayConfig.cs<br />->各Rayの情報を管理するクラス。Scriptable Object<br /><br />
RayMethod.cs<br />->レイで使用するメソッドをまとめたクラス。<br /><br />
RePlayCalc.cs<br />->RePlayに使用するクラス。<br /><br />
RePlayer.cs<br />->プレイヤ以外でリプレイ処理を使用したい場合に使用するクラス。MonoBehaviour<br /><br />
Recovery.cs<br />->数秒前の位置に車を戻す処理。<br /><br />
RigidbodyCalc.cs<br />->Rigidbodyに関する計算処理のクラス。<br /><br />
SpeedCalculator.cs<br />->速度の計算を行うクラス。<br /><br />
SpeedLimitController.cs<br />->最高速度を計算するクラス。<br /><br />
SteeringScript.cs<br />->ハンドルに対する車の挙動の処理を行うクラス。<br /><br />
VehicleCore.cs<br />->各クラスをnewして実際に使用するクラス。MonoBehaviour<br /><br />
VehicleMove.cs<br />->車の動きの処理を行うクラス。<br /><br />
VehicleSettings.cs<br />->車のパラメータをまとめたクラス。Scriptable Object<br /><br />
WallHitCheck.cs<br />->壁に衝突したか判定するクラス。<br /><br />
WheelData.cs<br />->タイヤに関するデータをまとめたクラス。<br /><br />
WheelParams.cs<br />->タイヤに関するデータを調整する為のクラス。Scriptable Object<br /><br />
WinGearManager.cs<br />->ギアの変更をWindowsようにキーバインドするクラス。MonoBehaviour<br /><br />

作品動画(Youtube)<br />
https://studio.youtube.com/video/KQCAAe6EQVg/edit
<br />
ポートフォリオ(Google Drive)<br />
https://drive.google.com/drive/u/2/folders/1nO7zj7kwnLvtC9zZ8SAd1OVzKLSmO4wQ
