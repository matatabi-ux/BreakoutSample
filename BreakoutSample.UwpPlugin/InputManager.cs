using System;
#if NETFX_CORE
using Windows.Storage.Streams;
using Windows.UI.Input;
#endif

namespace BreakoutSample.UwpPlugin
{
    /// <summary>
    /// 入力管理クラス
    /// </summary>
    public class InputManager
    {
        /// <summary>
        /// ダイアルボタンクリックフラグ
        /// </summary>
        public bool IsButtonClicked { get; set; }

        /// <summary>
        /// 水平移動量
        /// </summary>
        public float AxisXDelta { get; set; }

        /// <summary>
        /// インスタンス
        /// </summary>
        private static InputManager instance;

        /// <summary>
        /// インスタンス
        /// </summary>
        public static InputManager Instance
        {
            get
            {
                return instance ?? (instance = new InputManager());
            }
        }

        /// <summary>
        /// 加速度係数
        /// </summary>
        private const float Accel = 0.5f;

#if NETFX_CORE
        // <summary>
        /// Surface Dial 管理クラス
        /// </summary>
        private RadialController control;
#endif
        /// <summary>
        /// コンストラクタ
        /// </summary>
        private InputManager()
        {
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        static InputManager()
        {
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        public void Initialize()
        {
#if NETFX_CORE
            this.control = RadialController.CreateForCurrentView();

            // オリジナルのメニューを追加
            var icon = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/CatHand.png"));
            var item = RadialControllerMenuItem.CreateFromIcon("Play Game", icon);
            this.control.Menu.Items.Add(item);

            // イベントの購読
            this.control.ButtonClicked += this.OnButtonClicked;
            this.control.RotationChanged += this.OnRotationChanged;
#endif
        }

#if NETFX_CORE
        /// <summary>
        /// ダイアル回転イベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発行者</param>
        /// <param name="args">イベント引数</param>
        private void OnRotationChanged(RadialController sender, RadialControllerRotationChangedEventArgs args)
        {
            this.AxisXDelta = ((float)args.RotationDeltaInDegrees) * Accel;
        }

        /// <summary>
        /// ダイアルボタンクリックイベントハンドラ
        /// </summary>
        /// <param name="sender">イベント発行者</param>
        /// <param name="args">イベント引数</param>
        private void OnButtonClicked(RadialController sender, RadialControllerButtonClickedEventArgs args)
        {
            this.IsButtonClicked = true;
        }
#endif
    }
}