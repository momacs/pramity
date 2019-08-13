﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pram;

public class Tester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string twentySteps = "{\"simSteps\": [{\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 950.0}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 50.0}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 902.5}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 47.5}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 25.0}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 25.0}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 857.375}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 45.125}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 36.25}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 36.25}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 2.5}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 22.5}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 816.8812499999999}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 42.99375000000009}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 40.6875}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 40.6875}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 5.875}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 52.875}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 781.6184374999999}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 41.137812499999995}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 41.840625000000045}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 41.840625000000045}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 9.356250000000001}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 84.20625}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 751.425953125}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 39.54873437499998}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 41.48921875000002}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 41.48921875000002}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 12.604687500000004}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 113.44218750000005}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 725.8291085937499}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 38.20153203125005}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 40.5189765625}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 40.5189765625}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 15.493140625000008}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 139.43826562500007}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 704.2561367578123}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 37.066112460937575}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 39.36025429687503}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 39.36025429687503}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 17.99572421875001}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 161.96151796875006}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 686.1392679277342}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 36.1125930488281}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 38.2131833789063}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 38.2131833789063}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 20.13217722656251}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 181.1895950390626}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 670.9578728965818}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 35.313572257714895}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 37.162888213867205}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 37.162888213867205}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 21.940277841796892}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 197.462500576172}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 658.2532432014597}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 34.644907536918936}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 36.23823023579105}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 36.23823023579105}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 23.462538879003922}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 211.1628499110353}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 647.6299929764403}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 34.085789104023206}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 35.44156888635499}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 35.44156888635499}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 24.740108014682637}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 222.6609721321437}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 638.7515959415667}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 33.618505049556234}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 34.763678995189096}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 34.763678995189096}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 25.81025410184987}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 232.29228691664883}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 631.3337575412457}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 33.22809250217085}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 34.191092022372665}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 34.191092022372665}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 26.70559659118379}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 240.35036932065412}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 625.137386425808}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 32.90196770662146}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 33.709592262271755}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 33.709592262271755}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 27.454146134302682}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 247.08731520872414}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 619.9619559321052}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 32.629576628005566}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 33.30577998444661}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 33.30577998444661}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 28.07969074709959}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 252.7172167238963}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 615.6395643452445}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 32.402082333960266}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 32.96767830622609}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 32.96767830622609}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 28.602299670834295}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 257.42069703750866}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 612.0297708152748}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 32.21209320080402}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 32.68488032009318}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 32.68488032009318}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 29.038837534373478}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 261.34953780936127}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 609.0151779321658}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 32.053430417482446}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 32.4484867604486}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 32.4484867604486}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 29.403441812945445}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 264.63097631650896}]}, {\"redistributions\": [{\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 606.4976887578556}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 31.920930987255588}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"mass\": 32.250958588965524}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"i\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 32.250958588965524}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"s\"], \"site\": null, \"n\": 0}, \"mass\": 29.707946307695757}, {\"source\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"destination\": {\"attributeKeys\": [\"flu-status\"], \"attributeValues\": [\"r\"], \"site\": null, \"n\": 0}, \"mass\": 267.3715167692618}]}]}";
        SimInfo info = JsonUtility.FromJson<SimInfo>(twentySteps);
        int i = 0;
        foreach (RedistributionSet r in info.simSteps) {
            string toPrint = "";
            toPrint += "Step: " + i + "\n";
            foreach (Redistribution re in r.redistributions) {
                toPrint += re.ToString() + "\n";
            }
            print(toPrint);
        }
    }
}
