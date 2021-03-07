using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hibino {
    public class CapsuleAdaptive : MonoBehaviour
    {
        private CharacterController playerCollider;
        
        [SerializeField] Transform centerEye;

        //カプセルの最下部の頂点につけるEmptyのGameObjectのTransform
        [SerializeField] Transform cupsuleLower;

        private float firstCenterEyeHeight;
        private float centerEyeHeight;
        private float capsuleParam;

        void Start( ) {
            playerCollider = gameObject.GetComponent<CharacterController>( );

            //CenterEyeAnchorの高さの初期値を得る
            firstCenterEyeHeight = Mathf.Abs( centerEye.position.y - cupsuleLower.position.y );

            //初期値から係数を求める
            capsuleParam = playerCollider.height / firstCenterEyeHeight;
        }

        void Update( ) {
            // 計算の無駄を恐れて1/20秒で更新するようにしたがフレームレートの様子見で調整可能。別に1/60でもよいと思われ。
            if (Time.frameCount % 3 == 0) {
                //現在のCenterEyeAnchorの高さを求める
                centerEyeHeight = centerEye.position.y - cupsuleLower.position.y;

                if ( centerEyeHeight > 0 ) {
                    //Colliderのheightを現在のCenterEyeAnchorの高さに比例して変更する
                    playerCollider.height = capsuleParam * centerEyeHeight;

                    //Colliderのheightを変えるだけだと、位置も変わってしまうので、変わらないようにする
                    playerCollider.center = new Vector3(0, cupsuleLower.position.y + playerCollider.height / 2, 0);
                } else {
                    playerCollider.height = 0;
                }
            }
        }
    }
}
