




				v2f o;
                UNITY_SETUP_INSTANCE_ID(v);

                float4 worldPos = mul(unity_ObjectToWorld, v.vertex);
                float2 samplePos = worldPos.xz / _WaveControl.w;
                samplePos += _Time.x * -_WaveControl.xz;

                fixed waveSample = tex2Dlod(_Noise, float4(samplePos, 0, 0)).r;


                worldPos.x += sin(waveSample * _WindControl.x) * _WaveControl.x * _WindControl.w * v.uv.y;
                worldPos.z += sin(waveSample * _WindControl.z) * _WaveControl.z * _WindControl.w * v.uv.y;

                
                o.pos = mul(UNITY_MATRIX_VP, worldPos);
                o.uv = v.uv;

                //o.tempCol = waveSample;




