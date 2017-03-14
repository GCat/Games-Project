//Maya ASCII 2016 scene
//Name: kraken.ma
//Last modified: Mon, Mar 13, 2017 03:51:05 PM
//Codeset: 1252
requires maya "2016";
requires "stereoCamera" "10.0";
currentUnit -l centimeter -a degree -t film;
fileInfo "exportedFrom" "C:/Users/Anie/Documents/krakenTower.mb";
fileInfo "application" "maya";
fileInfo "product" "Maya 2016";
fileInfo "version" "2016";
fileInfo "cutIdentifier" "201510022200-973226";
fileInfo "osv" "Microsoft Windows 8 Home Premium Edition, 64-bit  (Build 9200)\n";
fileInfo "license" "student";
createNode transform -s -n "persp";
	rename -uid "D394E597-4E65-8CC5-4203-7D8F20A18DE0";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 5.1567060875004671 7.6300001092214638 -26.82866768343445 ;
	setAttr ".r" -type "double3" 1787.6616468881978 10258.599999998745 0 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "74415B99-487D-6E67-D30C-3EB6404C8B86";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999993;
	setAttr ".coi" 24.913306102799069;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".hc" -type "string" "viewSet -p %camera";
createNode transform -s -n "top";
	rename -uid "52780F73-4E34-B5D2-FD7D-AFB3150E05DC";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1.2955862896474017 100.1 -4.223343361925318 ;
	setAttr ".r" -type "double3" -89.999999999999986 0 0 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "9FD4E921-4EAA-1A8D-0B0E-D480FBBF9345";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100.1;
	setAttr ".ow" 17.295308302456188;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
createNode transform -s -n "front";
	rename -uid "ACDE533D-423A-FDDC-E0A7-FA96F1DFD3E0";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1.9313315008619989 1.818925963774793 100.1 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "35CB9CE8-44AB-4195-320D-40BFB85A49D5";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100.1;
	setAttr ".ow" 18.513694640122687;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
createNode transform -s -n "side";
	rename -uid "E9FB0452-4C20-72C4-E4D0-50A22DBCC954";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 100.1 0.61991867787781096 -4.8471123679226702 ;
	setAttr ".r" -type "double3" 0 89.999999999999986 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "2875F8DD-4CD7-DA8B-27B0-059C33607CCA";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 100.1;
	setAttr ".ow" 4.6301769884711543;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
createNode transform -n "krakenPond";
	rename -uid "4086468A-4F84-2D32-FB2A-16A4B5229892";
	setAttr ".t" -type "double3" 1.9907548993905659 0.40801370606803933 -2.0241201727897313 ;
	setAttr ".s" -type "double3" 1.9642365052062718 0.37777778022428277 1.9642365052062718 ;
createNode mesh -n "krakenPondShape" -p "krakenPond";
	rename -uid "33C5B05E-4CE1-DC23-736B-1E83868AFD40";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.87668307524912148 0.71598423813377421 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 66 ".uvst[0].uvsp[0:65]" -type "float2" 0.85829031 0.67191577
		 0.87182701 0.67191577 0.87182701 0.70317757 0.85829031 0.70317757 0.8447535 0.67191577
		 0.8447535 0.70317757 0.88885248 0.67191577 0.90238929 0.67191577 0.90238929 0.70317757
		 0.88885248 0.70317757 0.91592598 0.67191577 0.91592598 0.70317757 0.84573466 0.72888434
		 0.83497798 0.72888434 0.83497798 0.70356351 0.84573466 0.70356351 0.85649127 0.72888434
		 0.85649127 0.70356351 0.8630631 0.75459111 0.85230643 0.75459111 0.85230643 0.72927028
		 0.8630631 0.72927028 0.84154975 0.75459111 0.84154975 0.72927028 0.89776528 0.72700977
		 0.89776528 0.71137893 0.91130203 0.71919435 0.91130203 0.70356357 0.91130203 0.73482525
		 0.92483884 0.71137893 0.92483884 0.72700983 0.88530111 0.74142158 0.88530111 0.75384235
		 0.87454438 0.74763197 0.87454438 0.76005268 0.87454438 0.73521119 0.86378777 0.75384235
		 0.86378777 0.74142158 0.88363528 0.73482525 0.87009859 0.72700977 0.87287867 0.72540474
		 0.88363528 0.73161513 0.87009859 0.71137893 0.87287867 0.71298403 0.89717209 0.72700977
		 0.89439201 0.72540474 0.88363528 0.70356345 0.88363528 0.70677364 0.89717209 0.71137893
		 0.89439201 0.71298397 0.84415817 0.70317757 0.82852739 0.70317757 0.82852739 0.67191577
		 0.84415817 0.67191577 0.87245679 0.67191577 0.88808763 0.67191577 0.88808763 0.70317757
		 0.87245679 0.70317757 0.86950529 0.72888434 0.85708457 0.72888434 0.85708457 0.70356345
		 0.86950529 0.70356345 0.82852739 0.72927028 0.84094816 0.72927028 0.84094816 0.75459111
		 0.82852739 0.75459111;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 26 ".vt[0:25]"  0.50000024 -1 -0.86602533 -0.49999982 -1 -0.86602545
		 -1 -1 -1.1920929e-007 -0.50000012 -1 0.86602533 0.49999988 -1 0.86602545 0.99999988 -1 0
		 0.50000024 1.000000119209 -0.86602533 -0.49999982 1.000000119209 -0.86602545 -1 1.000000119209 -1.1920929e-007
		 -0.50000012 1.000000119209 0.86602533 0.49999988 1.000000119209 0.86602545 0.99999988 1.000000119209 0
		 0 -1 0 -0.7946279 1.000000119209 -1.1920929e-007 -0.39731401 1.000000119209 0.68816793
		 0.39731395 1.000000119209 0.68816793 0.79462779 1.000000119209 0 0.39731407 1.000000119209 -0.68816781
		 -0.39731383 1.000000119209 -0.68816781 0.39731407 -0.61992347 -0.68816781 -0.39731383 -0.61992347 -0.68816781
		 0 -0.61992347 0 -0.7946279 -0.61992347 -1.1920929e-007 -0.39731401 -0.61992347 0.68816793
		 0.39731395 -0.61992347 0.68816793 0.79462779 -0.61992347 0;
	setAttr -s 54 ".ed[0:53]"  0 1 0 1 2 0 2 3 0 3 4 0 4 5 0 5 0 0 6 7 0
		 7 8 0 8 9 0 9 10 0 10 11 0 11 6 0 0 6 0 1 7 0 2 8 0 3 9 0 4 10 0 5 11 0 12 0 1 12 1 1
		 12 2 1 12 3 1 12 4 1 12 5 1 6 17 1 7 18 1 8 13 1 9 14 1 10 15 1 11 16 1 13 14 0 14 15 0
		 15 16 0 16 17 0 17 18 0 18 13 0 17 19 0 18 20 0 19 20 0 20 21 1 19 21 1 13 22 0 20 22 0
		 22 21 1 14 23 0 22 23 0 23 21 1 15 24 0 23 24 0 24 21 1 16 25 0 24 25 0 25 21 1 25 19 0;
	setAttr -s 30 -ch 108 ".fc[0:29]" -type "polyFaces" 
		f 4 0 13 -7 -13
		mu 0 4 50 51 52 53
		f 4 1 14 -8 -14
		mu 0 4 4 0 3 5
		f 4 2 15 -9 -15
		mu 0 4 0 1 2 3
		f 4 3 16 -10 -16
		mu 0 4 54 55 56 57
		f 4 4 17 -11 -17
		mu 0 4 6 7 8 9
		f 4 5 12 -12 -18
		mu 0 4 7 10 11 8
		f 3 -1 -19 19
		mu 0 3 24 25 26
		f 3 -2 -20 20
		mu 0 3 28 24 26
		f 3 -3 -21 21
		mu 0 3 30 28 26
		f 3 -4 -22 22
		mu 0 3 29 30 26
		f 3 -5 -23 23
		mu 0 3 27 29 26
		f 3 -6 -24 18
		mu 0 3 25 27 26
		f 3 38 39 -41
		mu 0 3 31 32 33
		f 3 42 43 -40
		mu 0 3 32 34 33
		f 3 45 46 -44
		mu 0 3 34 36 33
		f 3 48 49 -47
		mu 0 3 36 37 33
		f 3 51 52 -50
		mu 0 3 37 35 33
		f 3 53 40 -53
		mu 0 3 35 31 33
		f 4 8 27 -31 -27
		mu 0 4 38 39 40 41
		f 4 9 28 -32 -28
		mu 0 4 39 42 43 40
		f 4 10 29 -33 -29
		mu 0 4 42 46 47 43
		f 4 11 24 -34 -30
		mu 0 4 46 48 49 47
		f 4 6 25 -35 -25
		mu 0 4 48 44 45 49
		f 4 7 26 -36 -26
		mu 0 4 44 38 41 45
		f 4 34 37 -39 -37
		mu 0 4 58 59 60 61
		f 4 35 41 -43 -38
		mu 0 4 16 12 15 17
		f 4 30 44 -46 -42
		mu 0 4 12 13 14 15
		f 4 31 47 -49 -45
		mu 0 4 62 63 64 65
		f 4 32 50 -52 -48
		mu 0 4 18 19 20 21
		f 4 33 36 -54 -51
		mu 0 4 19 22 23 20;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode transform -n "flag";
	rename -uid "C6697418-45E6-BB62-3CDB-578E550FAA18";
createNode transform -n "wood_of_flag" -p "|flag";
	rename -uid "227283D5-4CB5-D629-3A28-F585B86D1192";
	setAttr ".rp" -type "double3" 1.1207249164581299 1.4197089672088623 -0.54124146699905396 ;
	setAttr ".sp" -type "double3" 1.1207249164581299 1.4197089672088623 -0.54124146699905396 ;
createNode mesh -n "wood_of_flagShape" -p "wood_of_flag";
	rename -uid "56A4A405-4AC7-C282-0250-67A5FBC6A03B";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.50000001490116119 0.92267344204692159 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 95 ".uvst[0].uvsp[0:94]" -type "float2" 0.50402904 0.93990254
		 0.50402904 0.9408114 0.5 0.9408114 0.5 0.93990254 0.49194193 0.93990254 0.49194193
		 0.9408114 0.48791292 0.9408114 0.48791292 0.93990254 0.48791292 0.9045428 0.49194193
		 0.9045428 0.50805807 0.9045428 0.51208711 0.9045428 0.51208711 0.93990254 0.50805807
		 0.93944812 0.49244559 0.87634933 0.50755441 0.87634933 0.5 0.88882959 0.49597096
		 0.9045428 0.49597096 0.93944812 0.50402904 0.9045428 0.51510888 0.88943398 0.48489115
		 0.88943398 0.5 0.9045428 0.50755441 0.90251863 0.49244556 0.90251863 0.49194193 0.94089496
		 0.48791292 0.94089496 0.49268296 0.94089496 0.50616503 0.9664799 0.50755441 0.9689976
		 0.49244556 0.9689976 0.49383497 0.9664799 0.51208711 0.9408114 0.51208711 0.94089496
		 0.5113461 0.94089496 0.49105617 0.96659112 0.5089438 0.96659112 0.5 0.94089496 0.499259
		 0.94089496 0.50402904 0.94089496 0.49105617 0.94523478 0.49244559 0.9428283 0.49383497
		 0.94512355 0.50477004 0.94089496 0.50755441 0.9428283 0.50616503 0.94512355 0.5089438
		 0.94523478 0.48791292 0.9045428 0.49194193 0.9045428 0.49194193 0.92186952 0.48791292
		 0.92186952 0.50805807 0.9045428 0.51208711 0.9045428 0.51208711 0.92186952 0.5113461
		 0.92171323 0.5113461 0.92202568 0.5113461 0.92341208 0.5113461 0.92372453 0.51208711
		 0.92356825 0.51208711 0.94089496 0.50805807 0.94089496 0.49244559 0.87634933 0.50755441
		 0.87634933 0.5 0.88882959 0.49597096 0.9045428 0.49597096 0.92102003 0.50402904 0.9045428
		 0.50402904 0.94089496 0.50402904 0.92356825 0.50477004 0.92372453 0.50477004 0.92341208
		 0.50477004 0.92202568 0.50477004 0.92171323 0.50402904 0.92186952 0.51510888 0.88943398
		 0.49194193 0.92356825 0.49194193 0.94089496 0.48791292 0.94089496 0.48791292 0.92356825
		 0.51510888 0.95591295 0.50755441 0.9689976 0.5 0.95530856 0.48489115 0.88943398 0.5
		 0.9045428 0.5 0.92186952 0.50755441 0.90251863 0.50755441 0.9428283 0.5 0.94089496
		 0.5 0.92356825 0.49597096 0.92441773 0.49597096 0.94089496 0.49244556 0.9689976 0.49244556
		 0.90251863 0.49244559 0.9428283 0.48489115 0.95591295;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 43 ".vt[0:42]"  1.14572489 2.3549099 -0.49794018 1.14572489 2.40491009 -0.49794018
		 1.09572494 2.40491009 -0.49794018 1.09572494 2.3549099 -0.49794018 1.09572494 2.3549099 -0.58454275
		 1.09572494 2.40491009 -0.58454275 1.14572489 2.40491009 -0.58454275 1.14572489 2.3549099 -0.58454275
		 1.14572489 0.40950799 -0.58454275 1.09572494 0.40950799 -0.58454275 1.17072487 0.40950799 -0.54124147
		 1.17072487 2.32991004 -0.54124147 1.12072492 0.40950799 -0.54124147 1.070724964 0.40950799 -0.54124147
		 1.070724964 2.32991004 -0.54124147 1.14572489 0.40950799 -0.49794018 1.09572494 0.40950799 -0.49794018
		 1.09572494 2.40950799 -0.58454275 1.14572489 2.40950799 -0.58454275 1.091127038 2.40950799 -0.57657892
		 1.14112699 2.40950799 -0.57657892 1.10032284 2.40950799 -0.57657892 1.15032279 2.40950799 -0.57657892
		 1.09572494 2.40950799 -0.49794018 1.091127038 2.40950799 -0.50590402 1.14572489 2.40950799 -0.49794018
		 1.10032284 2.40950799 -0.50590402 1.15032279 2.40950799 -0.50590402 1.14112699 2.40950799 -0.50590402
		 1.65569139 2.40491009 -0.58454275 1.65569139 2.3549099 -0.58454275 1.65569139 2.42990994 -0.54124147
		 0.58575845 2.40491009 -0.58454275 0.58575845 2.42990994 -0.54124147 1.65569139 2.37990999 -0.54124147
		 1.65569139 2.32991004 -0.54124147 1.65569139 2.40491009 -0.49794018 0.58575845 2.40491009 -0.49794018
		 0.58575845 2.3549099 -0.58454275 0.58575845 2.37990999 -0.54124147 1.65569139 2.3549099 -0.49794018
		 0.58575845 2.3549099 -0.49794018 0.58575845 2.32991004 -0.54124147;
	setAttr -s 89 ".ed[0:88]"  0 1 1 1 2 1 2 3 1 3 0 1 4 5 1 5 6 1 6 7 1
		 7 4 1 8 9 0 9 4 0 7 8 0 10 8 0 7 11 0 11 10 0 8 12 1 12 9 1 9 13 0 13 14 0 14 4 0
		 15 10 0 11 0 0 0 15 0 10 12 1 12 13 1 13 16 0 16 3 0 3 14 0 16 15 0 15 12 1 12 16 1
		 5 17 0 17 18 0 18 6 0 19 17 0 5 19 0 20 18 1 17 21 1 21 20 1 18 22 0 22 6 0 19 21 0
		 20 22 0 2 23 0 23 24 0 24 2 0 1 25 0 25 23 0 23 26 1 26 24 0 27 25 0 1 27 0 25 28 1
		 28 26 1 27 28 0 29 30 0 30 7 0 6 29 0 31 29 0 5 32 0 32 33 0 33 31 0 29 34 1 34 30 1
		 30 35 0 35 11 0 36 31 0 33 37 0 37 2 0 1 36 0 31 34 1 4 38 0 38 32 0 32 39 1 39 33 1
		 34 35 1 35 40 0 40 0 0 40 36 0 36 34 1 39 37 1 37 41 0 41 3 0 14 42 0 42 38 0 38 39 1
		 34 40 1 39 41 1 41 42 0 42 39 1;
	setAttr -s 48 -ch 178 ".fc[0:47]" -type "polyFaces" 
		f 4 0 1 2 3
		mu 0 4 0 1 2 3
		f 4 4 5 6 7
		mu 0 4 4 5 6 7
		f 4 8 9 -8 10
		mu 0 4 8 9 4 7
		f 4 11 -11 12 13
		mu 0 4 10 11 12 13
		f 3 -9 14 15
		mu 0 3 14 15 16
		f 4 16 17 18 -10
		mu 0 4 9 17 18 4
		f 4 19 -14 20 21
		mu 0 4 19 10 13 0
		f 3 -12 22 -15
		mu 0 3 15 20 16
		f 3 -17 -16 23
		mu 0 3 21 14 16
		f 4 24 25 26 -18
		mu 0 4 17 22 3 18
		f 4 27 -22 -4 -26
		mu 0 4 22 19 0 3
		f 3 -20 28 -23
		mu 0 3 20 23 16
		f 3 -25 -24 29
		mu 0 3 24 21 16
		f 3 -28 -30 -29
		mu 0 3 23 24 16
		f 4 30 31 32 -6
		mu 0 4 5 25 26 6
		f 3 33 -31 34
		mu 0 3 27 25 5
		f 4 35 -32 36 37
		mu 0 4 28 29 30 31
		f 3 -33 38 39
		mu 0 3 32 33 34
		f 3 -37 -34 40
		mu 0 3 31 30 35
		f 3 -39 -36 41
		mu 0 3 36 29 28
		f 3 42 43 44
		mu 0 3 2 37 38
		f 4 45 46 -43 -2
		mu 0 4 1 39 37 2
		f 3 -44 47 48
		mu 0 3 40 41 42
		f 3 49 -46 50
		mu 0 3 43 39 1
		f 4 -48 -47 51 52
		mu 0 4 42 41 44 45
		f 3 -52 -50 53
		mu 0 3 45 44 46
		f 4 54 55 -7 56
		mu 0 4 47 48 49 50
		f 10 57 -57 -40 -42 -38 -41 -35 58 59 60
		mu 0 10 51 52 53 54 55 56 57 58 59 60
		f 3 -55 61 62
		mu 0 3 61 62 63
		f 4 63 64 -13 -56
		mu 0 4 48 64 65 49
		f 10 65 -61 66 67 -45 -49 -53 -54 -51 68
		mu 0 10 66 51 60 67 68 69 70 71 72 73
		f 3 -58 69 -62
		mu 0 3 62 74 63
		f 4 70 71 -59 -5
		mu 0 4 75 76 77 78
		f 3 -60 72 73
		mu 0 3 79 80 81
		f 3 -64 -63 74
		mu 0 3 82 61 63
		f 4 75 76 -21 -65
		mu 0 4 64 83 84 65
		f 4 77 -69 -1 -77
		mu 0 4 83 66 73 84
		f 3 -66 78 -70
		mu 0 3 74 85 63
		f 3 -67 -74 79
		mu 0 3 86 79 81
		f 4 -68 80 81 -3
		mu 0 4 68 67 87 88
		f 4 82 83 -71 -19
		mu 0 4 89 90 76 75
		f 3 -72 84 -73
		mu 0 3 80 91 81
		f 3 -76 -75 85
		mu 0 3 92 82 63
		f 3 -78 -86 -79
		mu 0 3 85 92 63
		f 3 -81 -80 86
		mu 0 3 93 86 81
		f 4 -82 87 -83 -27
		mu 0 4 88 87 90 89
		f 3 -84 88 -85
		mu 0 3 91 94 81
		f 3 -88 -87 -89
		mu 0 3 94 93 81;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode transform -n "flag" -p "|flag";
	rename -uid "B69731B9-4613-EB83-F562-72994EA03167";
	setAttr ".rp" -type "double3" 1.1240553557872772 1.911502480506897 -0.53896665573120117 ;
	setAttr ".sp" -type "double3" 1.1240553557872772 1.911502480506897 -0.53896665573120117 ;
createNode mesh -n "flagShape" -p "|flag|flag";
	rename -uid "EE3C5428-4E58-E146-8316-14AC171677BA";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.83507275044253082 0.91829339147688038 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 67 ".uvst[0].uvsp[0:66]" -type "float2" 0.82267833 0.89271677
		 0.83515996 0.89271677 0.83515996 0.89350462 0.82267833 0.89350462 0.79788947 0.89271677
		 0.79788947 0.89350462 0.82267833 0.86871576 0.83515996 0.86871576 0.84746712 0.89271677
		 0.84746712 0.89350462 0.83515996 0.91829342 0.82267833 0.91829342 0.83515996 0.91908121
		 0.82267827 0.91908121 0.79788947 0.86871576 0.82267833 0.94308227 0.83515996 0.94308227
		 0.83515996 0.96787107 0.82267833 0.96787107 0.84746712 0.86871576 0.84746712 0.91829342
		 0.87225604 0.89271677 0.87225604 0.89350462 0.84746712 0.91908121 0.84746712 0.94308227
		 0.84746712 0.96787107 0.87225604 0.86871576 0.83282316 0.90210795 0.83366466 0.90210795
		 0.8306312 0.90344542 0.8306312 0.90344542 0.83282316 0.86773288 0.83366466 0.86773288
		 0.83282316 0.85199076 0.83366466 0.85199076 0.88002789 0.90210795 0.88086939 0.90210795
		 0.88306135 0.90344542 0.88306129 0.90344542 0.88002789 0.86773288 0.88086939 0.86773288
		 0.88002789 0.85199076 0.88086939 0.85199076 0.87806857 0.90381861 0.87806857 0.92603564
		 0.87503505 0.92603564 0.87503505 0.90381861 0.87806857 0.94892561 0.87503505 0.94892561
		 0.87503505 0.92603564 0.87503505 0.90381861 0.87503505 0.94892561 0.92374915 0.93819362
		 0.90153217 0.9539358 0.90153217 0.90381861 0.92374915 0.90381861 0.87864208 0.93819362
		 0.87864208 0.90381861 0.87940061 0.90210795 0.85718358 0.90210795 0.85718358 0.85199076
		 0.87940061 0.86773288 0.87940061 0.90344542 0.85718358 0.90344542 0.8342936 0.90210795
		 0.8342936 0.86773288 0.8342936 0.90344542;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 36 ".vt[0:35]"  1.58731401 2.4127152 -0.60196865 1.13075304 2.4127152 -0.60196865
		 1.13075304 2.44020033 -0.53963131 1.58731401 2.44020033 -0.53963131 1.58731401 2.4127152 -0.5846765
		 1.58731401 2.44020033 -0.53963113 1.58731401 1.70630693 -0.60196865 1.13075304 1.38280463 -0.60196865
		 0.6603629 2.4127152 -0.60196865 0.6603629 2.44020033 -0.53963131 1.13075304 2.44020033 -0.53963113
		 1.13075304 2.4127152 -0.5846765 1.58731401 1.70630693 -0.5846765 1.13075304 1.38280463 -0.5846765
		 0.6603629 1.70630693 -0.60196865 0.6603629 2.44020033 -0.53963113 0.6603629 2.4127152 -0.5846765
		 0.6603629 1.70630693 -0.5846765 0.66079664 2.4127152 -0.47596467 1.11735773 2.4127152 -0.47596467
		 1.11735773 2.44020033 -0.538302 0.66079664 2.44020033 -0.538302 0.66079664 2.4127152 -0.49325675
		 0.66079664 2.44020033 -0.53830218 0.66079664 1.70630693 -0.47596467 1.11735773 1.38280463 -0.47596467
		 1.58774781 2.4127152 -0.47596467 1.58774781 2.44020033 -0.538302 1.11735773 2.44020033 -0.53830218
		 1.11735773 2.4127152 -0.49325675 0.66079664 1.70630693 -0.49325675 1.11735773 1.38280463 -0.49325675
		 1.58774781 1.70630693 -0.47596467 1.58774781 2.44020033 -0.53830218 1.58774781 2.4127152 -0.49325675
		 1.58774781 1.70630693 -0.49325675;
	setAttr -s 64 ".ed[0:63]"  0 1 1 1 2 1 2 3 0 3 0 0 4 0 1 3 5 0 5 4 0
		 6 7 0 7 1 1 0 6 0 1 8 1 8 9 0 9 2 0 2 10 1 10 5 0 10 11 1 11 4 1 12 6 0 4 12 0 12 13 0
		 13 7 1 7 14 0 14 8 0 9 15 0 15 10 0 8 16 1 16 15 0 16 11 1 11 13 1 13 17 0 17 14 0
		 17 16 0 18 19 1 19 20 1 20 21 0 21 18 0 22 18 1 21 23 0 23 22 0 24 25 0 25 19 1 18 24 0
		 19 26 1 26 27 0 27 20 0 20 28 1 28 23 0 28 29 1 29 22 1 30 24 0 22 30 0 30 31 0 31 25 1
		 25 32 0 32 26 0 27 33 0 33 28 0 26 34 1 34 33 0 34 29 1 29 31 1 31 35 0 35 32 0 35 34 0;
	setAttr -s 32 -ch 128 ".fc[0:31]" -type "polyFaces" 
		f 4 0 1 2 3
		mu 0 4 43 44 45 46
		f 4 4 -4 5 6
		mu 0 4 27 28 29 30
		f 4 7 8 -1 9
		mu 0 4 52 53 54 55
		f 4 -2 10 11 12
		mu 0 4 45 44 47 48
		f 4 -3 13 14 -6
		mu 0 4 46 45 49 50
		f 4 -15 15 16 -7
		mu 0 4 62 63 59 58
		f 4 17 -10 -5 18
		mu 0 4 31 32 28 27
		f 4 19 20 -8 -18
		mu 0 4 31 33 34 32
		f 4 21 22 -11 -9
		mu 0 4 53 56 57 54
		f 4 -14 -13 23 24
		mu 0 4 49 45 48 51
		f 4 25 26 -24 -12
		mu 0 4 35 36 37 38
		f 4 -16 -25 -27 27
		mu 0 4 59 63 66 64
		f 4 -17 28 -20 -19
		mu 0 4 58 59 60 61
		f 4 -21 29 30 -22
		mu 0 4 41 42 40 39
		f 4 -31 31 -26 -23
		mu 0 4 39 40 36 35
		f 4 -29 -28 -32 -30
		mu 0 4 60 59 64 65
		f 4 32 33 34 35
		mu 0 4 0 1 2 3
		f 4 36 -36 37 38
		mu 0 4 4 0 3 5
		f 4 39 40 -33 41
		mu 0 4 6 7 1 0
		f 4 -34 42 43 44
		mu 0 4 2 1 8 9
		f 4 -35 45 46 -38
		mu 0 4 3 2 10 11
		f 4 -47 47 48 -39
		mu 0 4 11 10 12 13
		f 4 49 -42 -37 50
		mu 0 4 14 6 0 4
		f 4 51 52 -40 -50
		mu 0 4 15 16 17 18
		f 4 53 54 -43 -41
		mu 0 4 7 19 8 1
		f 4 -46 -45 55 56
		mu 0 4 10 2 9 20
		f 4 57 58 -56 -44
		mu 0 4 8 21 22 9
		f 4 -48 -57 -59 59
		mu 0 4 12 10 20 23
		f 4 -49 60 -52 -51
		mu 0 4 13 12 16 15
		f 4 -53 61 62 -54
		mu 0 4 17 16 24 25
		f 4 -63 63 -58 -55
		mu 0 4 19 26 21 8
		f 4 -61 -60 -64 -62
		mu 0 4 16 12 23 24;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode transform -n "kraken";
	rename -uid "8565E0FA-474F-0028-201E-BCB096BB974A";
	setAttr ".t" -type "double3" 2.0045052490946738 0.86382702011693047 -1.3685856195384933 ;
	setAttr -l on ".tx";
	setAttr -l on ".ty";
	setAttr -l on ".tz";
	setAttr -l on ".rx";
	setAttr -l on ".ry";
	setAttr -l on ".rz";
	setAttr -l on ".sx";
	setAttr -l on ".sy";
	setAttr -l on ".sz";
createNode mesh -n "krakenShape" -p "kraken";
	rename -uid "63D01D5F-4F86-5C3E-9726-AAA27E0533FE";
	setAttr -k off ".v";
	setAttr -s 14 ".iog[0].og";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.33331835269927979 0.81416630744934082 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".clst[0].clsn" -type "string" "SculptFreezeColorTemp";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr ".dfgi" 0;
	setAttr ".dr" 1;
	setAttr ".vcs" 2;
createNode joint -n "middleKraken" -p "kraken";
	rename -uid "CAA039FA-4145-F963-037B-62BDBB39D574";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 2.0008258927344804 0.66772283139307453 -1.4952817023523011 1;
	setAttr ".radi" 2;
createNode joint -n "right" -p "middleKraken";
	rename -uid "F128854D-4645-9CFF-D2CA-F69E3EE13061";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 1;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 2.7341488723990164 0.65266335404794096 -1.5581053913616687 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint28" -p "right";
	rename -uid "6C0C8484-47B7-95D5-49D7-C2AFB33128EA";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 2;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 2.9948229439762519 0.70946594854429068 -2.4479997260200443 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint29" -p "joint28";
	rename -uid "FE77EAD3-4BD1-E218-ED98-5D9597C83886";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 3;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 3.069585104711245 1.3297722623272918 -3.3745911924815766 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint30" -p "joint29";
	rename -uid "3207FE4A-4B54-EC6B-B25F-4BA510164AF9";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 4;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 3.3686337476512174 1.3940936688218537 -4.5266122785648832 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint31" -p "joint30";
	rename -uid "96132402-4DE0-6217-60EF-E0ADE30FDADD";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 5;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 3.3942880712990124 0.68090838065752302 -5.1854790798191983 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint32" -p "joint31";
	rename -uid "040BA7EC-40F8-0103-4D08-FF90CCC71E9F";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 6;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 3.6897065039068639 0.45871722486401545 -6.2143019492265186 1;
	setAttr ".radi" 0.5;
createNode joint -n "front_right" -p "middleKraken";
	rename -uid "62183F22-4A7E-10C0-C273-03A778E5F705";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 1;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 2.4102118458167734 0.67030290415734428 -1.8643000050336827 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint1" -p "front_right";
	rename -uid "2328C59F-470E-2C90-D81B-F695429AAFBC";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 2;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 0.9908994417877407 0.13460422082811474 0
		 0 -0.13460422082811474 0.9908994417877407 0 2.3992872876054392 0.71135210478358335 -2.4382497990416478 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint2" -p "joint1";
	rename -uid "654CCBCC-4AA6-D567-491D-94B57DFD65C1";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 3;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".jo" -type "double3" -7.7357345270432161 0 0 ;
	setAttr ".bps" -type "matrix" 0.89810206899679212 6.9388939039072284e-018 0.43978707764517277 0
		 3.4694469519536142e-018 1 0 0 -0.43978707764517283 0 0.89810206899679212 0 2.4245479256241635 1.1032124875509526 -3.1214167301665974 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint3" -p "joint2";
	rename -uid "435ED4C5-41A0-27FD-355F-1C93459472B5";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 4;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".jo" -type "double3" 0 26.09029664503678 0 ;
	setAttr ".bps" -type "matrix" 1 6.2318349716483099e-018 -5.5511151231257827e-017 0
		 3.4694469519536142e-018 1 0 0 0 3.0516358720892647e-018 1 0 2.4178692965743984 1.1833895691964682 -4.2037783862941343 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint4" -p "joint3";
	rename -uid "263F4B26-4C13-5639-CBDE-159DC9A52755";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 5;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 6.2318349716483099e-018 -5.5511151231257827e-017 0
		 3.4694469519536142e-018 1 0 0 0 3.0516358720892647e-018 1 0 2.4178692965743984 0.49901969785393252 -5.0397384362794337 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint5" -p "joint4";
	rename -uid "416698C0-438B-ABF8-8B7A-C1A48D6618D0";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 6;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 6.2318349716483099e-018 -5.5511151231257827e-017 0
		 3.4694469519536142e-018 1 0 0 0 3.0516358720892647e-018 1 0 2.4355125575279444 0.24238099610048103 -6.1381073729231508 1;
	setAttr ".radi" 0.5;
createNode joint -n "front_left" -p "middleKraken";
	rename -uid "46200654-4979-66C3-6A70-8DBEA39F2423";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 1;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 1.6050012946018377 0.70558200437615204 -1.8551498851335131 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint6" -p "front_left";
	rename -uid "F169A5CB-4CDC-AF5A-D730-EE87FED769E6";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 2;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 1.5529689897889716 0.71288528264847462 -2.4462145691075299 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint7" -p "joint6";
	rename -uid "417854B0-4375-4B0C-C6CC-FF94344B8E11";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 3;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 1.5934836607468059 1.097843335278651 -3.1222119004051283 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint8" -p "joint7";
	rename -uid "E782888B-4356-98E2-3A42-AF8A17C26B92";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 4;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 1.5989464262400077 1.183389569196468 -4.2038336023190013 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint9" -p "joint8";
	rename -uid "A4E24854-4272-D39C-4BE7-70A3122DA38C";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 5;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 1.5923043010169708 0.49901969785393219 -5.0392723847106895 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint10" -p "joint9";
	rename -uid "EE6BD91B-414B-6422-7E48-6883EA0371FB";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 6;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 1.618546416755394 0.24238099610048158 -6.1365856884654839 1;
	setAttr ".radi" 0.5;
createNode joint -n "left" -p "middleKraken";
	rename -uid "E11888BB-420D-7D7B-2989-9791226B0E4A";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 1;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 1.2664468582955579 0.67030290415734495 -1.5348956886275729 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint11" -p "left";
	rename -uid "2AD40E80-4834-46AE-51AC-029F95B44340";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 2;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 1.0348582699005529 0.70252680857187966 -2.4406464399397159 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint12" -p "joint11";
	rename -uid "970BF6C8-4059-ED58-E90A-A09CAD279739";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 3;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0.94436855853219193 1.3304101437329969 -3.3843248584954817 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint13" -p "joint12";
	rename -uid "A4E24CF9-40A1-542A-1153-B18023494897";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 4;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0.63342797957852692 1.3972715492975494 -4.5185403983571559 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint14" -p "joint13";
	rename -uid "239045F6-4AEC-18DA-5430-80B95B906C74";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 5;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0.60826391630685128 0.6763441651915707 -5.1823915475982112 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint15" -p "joint14";
	rename -uid "B70F126C-43F6-D449-8D3E-D8A2086C4B94";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 6;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0.32386768057771631 0.44781469307446586 -6.2089761149613913 1;
	setAttr ".radi" 0.5;
createNode joint -n "back_left" -p "middleKraken";
	rename -uid "BCFD2474-4BE1-7A3A-FFE5-65B5ACA7114C";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 1;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 1.5135000956001403 0.61738425382913364 -1.1414405329202746 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint16" -p "back_left";
	rename -uid "141EBF50-4170-9C3B-3415-E49A353E6124";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 2;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 1.0049140666299963 0.94842497177875584 -1.1233479680408935 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint17" -p "joint16";
	rename -uid "3A36DA41-4E8F-652D-23F3-679A0532960A";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 3;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 0.43745928214216967 0.96501129263477203 -1.1350645327279865 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint18" -p "joint17";
	rename -uid "1D07EF46-40B0-2910-81C7-7495605A90DA";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 4;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 -0.43316300978297884 1.0702649868126515 -1.5280329744686663 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint19" -p "joint18";
	rename -uid "FEEE8F63-43C1-1EE1-930C-178650688DCF";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 5;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 -0.79579571302018515 1.124663429090148 -2.3894986504511491 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint20" -p "joint19";
	rename -uid "1BCCBF8E-49BC-FCDE-7A4A-E9A0642813E0";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 6;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 -0.93179274984576876 0.1805875173877558 -3.2985298775901688 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint21" -p "joint20";
	rename -uid "B2A95E77-4E8F-7E8E-5DA0-4C92AC95BF81";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 7;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 -0.92856846694577277 0.13688935015665482 -4.2857026871324333 1;
	setAttr ".radi" 0.5;
createNode joint -n "back_right" -p "middleKraken";
	rename -uid "E7D2B3E9-4CA8-6CE5-8FBE-32AC43049213";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 1;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 2.5017130448184708 0.63502380393853697 -1.1505906528204441 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint22" -p "back_right";
	rename -uid "267F9A54-4319-71DA-DD07-DF8A03FEB6DF";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 2;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 3.0018495647014936 0.93415602394380581 -1.135823972969622 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint23" -p "joint22";
	rename -uid "57ACB8DE-4C91-C5D5-3C63-80A7634C8091";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 3;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 3.5907182275357021 1.0110584559787217 -1.1702488406694975 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint24" -p "joint23";
	rename -uid "5B7FBBA1-45E6-31FD-82C6-60B770D78697";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 4;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 4.4447139010478027 1.0943948423749539 -1.5122421407656805 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint25" -p "joint24";
	rename -uid "EC441B7C-41A5-A788-ACAF-5384606E6996";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 5;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 4.807776564986618 1.1401813481214891 -2.4245534501503947 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint26" -p "joint25";
	rename -uid "5ADB6F33-4487-7FFC-E338-8481D4A2131E";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 6;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 4.9947107436373175 0.19183373652270364 -3.3050951577447201 1;
	setAttr ".radi" 0.5;
createNode joint -n "joint27" -p "joint26";
	rename -uid "2137E68D-4B30-1FD5-69D8-0BA97C9E4964";
	addAttr -ci true -sn "liw" -ln "lockInfluenceWeights" -min 0 -max 1 -at "bool";
	setAttr ".uoc" 1;
	setAttr ".oc" 7;
	setAttr ".mnrl" -type "double3" -360 -360 -360 ;
	setAttr ".mxrl" -type "double3" 360 360 360 ;
	setAttr ".dh" yes;
	setAttr ".bps" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 4.9199485829023253 0.12788915768180287 -4.2902849965363341 1;
	setAttr ".radi" 0.5;
createNode mesh -n "krakenShapeOrig1" -p "kraken";
	rename -uid "9BE0D654-416B-3B55-8BCE-2A8E5C1F8E34";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 573 ".uvst[0].uvsp";
	setAttr ".uvst[0].uvsp[0:249]" -type "float2" 0.38998902 0.15900606 0.38998902
		 0.14564663 0.42450041 0.14564663 0.42450041 0.15900606 0.4473134 0.14698258 0.4418028
		 0.1617108 0.45456302 0.14564663 0.44879329 0.15956426 0.44984818 0.12948585 0.46189237
		 0.12948585 0.46820635 0.14564663 0.45937639 0.15956426 0.43168861 0.14564663 0.43168861
		 0.12948585 0.44984818 0.092321873 0.46265018 0.10227054 0.46957135 0.12948585 0.42450041
		 0.12948585 0.42450041 0.087987602 0.42450041 0.077205598 0.44740659 0.081672609 0.44955361
		 0.088121697 1.34463191 1.17609513 1.4027276 1.24260068 1.40626395 1.22854948 1.41744649
		 1.23308349 1.32086396 1.13680506 1.32968879 1.12576103 0.82853335 0.62158781 0.83601254
		 0.6374737 0.84242088 0.62252569 0.84496576 0.63192225 0.84691423 0.61379337 0.86461478
		 0.63179779 0.87807149 0.63618362 0.87663728 0.64875317 0.82016271 0.66622454 0.828942
		 0.65488201 0.85725492 0.64497936 0.82362133 0.66225791 0.8101812 0.65740973 0.81508476
		 0.69367385 1.36332476 1.20154977 0.79026634 0.70884198 0.79300565 0.66597128 1.34764242
		 1.25287771 1.33971012 1.24250603 0.78951508 0.71776301 1.1088922 0.82383084 1.36160076
		 1.22538137 1.018960118 1.1630733 1.10602164 0.63840663 1.10609722 0.58904827 0.97430539
		 1.16213894 0.97121191 1.11346388 0.97138292 1.18476725 0.94518578 1.099639297 1.0055346489
		 1.17482638 0.91944683 1.10816908 0.94562912 1.18903601 0.89217198 1.10467696 0.77751982
		 0.4646062 0.93464184 0.48291805 0.96542722 0.50433308 0.94193697 0.54786247 0.94537336
		 0.53514093 0.93910396 0.50933611 0.92407924 0.51217252 0.93856728 0.61889881 0.93414783
		 0.62193501 0.93470883 0.7550233 0.90248507 0.75802207 0.90169883 0.87488592 0.86947298
		 0.87787914 0.87513256 1.016369104 0.84290808 1.019366622 0.38025478 0.49923077 0.43997717
		 0.48461053 0.45442319 0.56434178 0.38748863 0.58312947 0.43581134 0.59305227 0.44007671
		 0.57021558 0.52727115 0.72024465 0.49625689 0.71983445 0.50367171 0.84487867 0.47201782
		 0.84571958 0.46053118 0.99102426 0.42887697 0.99186617 0.84331465 1.019188166 0.79642242
		 1.047444463 0.8364296 0.779872 0.89241958 0.74783218 0.90527278 0.84293044 0.84544015
		 0.84065616 0.95322561 0.7588973 0.95548248 0.76283514 0.98790252 0.73868072 0.99018401
		 0.74259329 0.91111374 0.73864746 0.9134028 0.74255681 0.8970899 0.72592258 0.89937943
		 0.72983181 0.58244658 0.4788354 0.62214983 0.46187526 0.66197085 0.57501632 0.60548967
		 0.58368176 0.75936133 0.70090353 0.71204311 0.70789862 0.77935213 0.8360424 0.73203248
		 0.84303999 0.67723566 0.74151814 0.71181077 0.80911094 0.71333915 0.98456407 0.66602141
		 0.99155509 0.48007268 0.45680469 0.47065675 0.47084808 0.77057135 0.84469289 0.71467131
		 0.83367854 0.69273174 0.79942918 0.70814216 0.79450679 0.72465569 0.79418838 0.73445904
		 0.78699505 0.74594998 0.75793159 0.75576937 0.75078678 0.68902266 0.76450956 0.69880503
		 0.75726879 1.41046917 0.74092776 1.45274973 0.76039982 1.29611754 0.81110144 1.23592114
		 0.80665565 1.2178874 0.79572231 1.23072326 0.79199076 1.25942194 0.77357149 1.26741338
		 0.77001202 1.22550273 0.87163734 1.25375414 0.80679697 1.28012919 0.8086521 1.28735232
		 0.80650473 0.94879001 0.4965457 0.99227333 0.48877892 0.95653397 0.46421498 0.96132779
		 0.47028768 1.1220727 0.50911117 1.13497961 0.509817 1.17375731 0.63906795 1.11803806
		 0.64662254 1.20574582 0.74399906 1.15431583 0.74888027 1.20109069 0.9037298 1.15051174
		 0.90849733 1.51225305 0.1234173 1.48268867 0.13540821 1.47856355 0.21358736 1.45423913
		 0.20117052 0.59585631 0.84614789 0.60818315 0.83208293 0.65807652 0.90765345 0.6413511
		 0.92293781 0.63120139 0.95301968 0.62125772 0.96860939 0.69192362 0.76287985 0.71344703
		 0.84059101 0.64202517 0.92604327 0.64574289 0.92872882 0.61474901 0.79092389 0.63574934
		 0.86969846 0.96736419 0.851592 0.96012533 0.83606857 0.98853552 0.77591467 1.0053802729
		 0.79118627 1.027225733 0.85686851 1.026239991 0.81346947 0.99458748 0.79059929 0.99558532
		 0.79328489 0.98180664 0.84503311 0.97197539 0.77278972 1.0091415644 0.83039659 0.96148551
		 0.83289564 0.51835966 1.27704263 0.50092554 1.26175821 0.55179864 1.16444969 0.56878245
		 1.18003941 0.41799605 1.13322747 0.43602341 1.11967301 0.6081183 1.19080937 0.62293553
		 1.11967039 0.52661532 0.91877854 0.56239808 0.92266488 0.56207931 0.93341482 0.57817352
		 0.86237907 0.90263498 0.89415729 0.91994005 0.87827182 0.97493774 0.961595 0.95765269
		 0.97779769 0.89926422 0.89361131 0.9028756 0.94000477 0.93670821 1.091987371 0.91394508
		 1.096026659 0.97767305 1.14856184 0.94430006 1.22752333 0.95871484 1.28614068 0.9693228
		 1.29017997 0.97429526 0.1378053 0.96398276 0.12590598 0.97734225 0.11182801 0.98765481
		 0.12610485 -0.38800171 -0.25074202 -0.38800171 -0.26501831 -0.37184095 -0.28927693
		 -0.35848144 -0.28927693 -0.43364912 -0.25074202 -0.43364912 -0.26501831 -0.38800171
		 -0.28927693 -0.37184095 -0.22798994 -0.38800171 -0.22798994 -0.37184095 -0.31278202
		 -0.35848144 -0.31278202 -0.47898209 -0.25074202 -0.47898209 -0.26501831 -0.42092875
		 -0.28927693 -0.39178982 -0.22476441 -0.41975361 -0.23545218 -0.38800171 -0.31278202
		 -0.37184095 -0.21356669 -0.38800171 -0.21356669 -0.37184095 -0.32590967 -0.35848144
		 -0.32590967 -0.52699256 -0.25074202 -0.52699256 -0.26501831 -0.43364912 -0.31278202
		 -0.46329278 -0.20770389 -0.49125656 -0.2212604 -0.38800171 -0.32590967 -0.37042373
		 -0.16924533 -0.38941893 -0.16924533 -0.60950249 -0.25074202 -0.60950249 -0.26501831
		 -0.43364912 -0.32590967 -0.38800171 -0.34866175 -0.37184095 -0.34866175 -0.39773747
		 -0.1003328 -0.41711205 -0.10894677 -0.67355502 -0.25074202 -0.67355502 -0.26501831
		 -0.47898209 -0.31278202 -0.47898209 -0.32590967 -0.41975361 -0.34119952 -0.39178982
		 -0.35188729 -0.084708869 -0.56776118 -0.068548113 -0.56776118;
	setAttr ".uvst[0].uvsp[250:499]" -0.1694701 -0.27181292 -0.17280784 -0.29178923
		 -0.45201686 -0.45541817 -0.45201686 -0.46969447 -0.2236997 -0.5174582 -0.2236997
		 -0.53058583 -0.18796372 -0.56006747 -0.15999994 -0.57362396 -0.086126089 -0.61208248
		 -0.067130893 -0.61208248 -0.23711953 -0.25850213 -0.24045725 -0.28446829 0.75065005
		 0.064066872 0.75065005 0.065014616 0.93355769 -0.079321623 0.95293224 -0.099759549
		 0.65833819 0.31764036 0.671956 0.29047704 0.61707342 0.077048942 0.60011774 0.065014616
		 0.73153871 -0.10165565 0.73480397 -0.13856818 0.4699046 0.057696626 0.46987087 0.065113798
		 0.52226126 -0.13810274 0.53657413 -0.160045 0.45682186 -0.096353799 0.45216906 -0.11863413
		 0.70122927 0.77828997 0.70707637 0.74726856 0.72063905 0.74739099 0.71530205 0.77188474
		 0.68614101 0.77821046 0.68367606 0.74739099 0.71315247 0.7845549 0.70907938 0.78802764
		 1.27210081 0.78284919 1.23250723 0.77156168 1.22442842 0.73117816 1.2532866 0.71633327
		 1.2894299 0.72678655 1.2775929 0.77982694 1.26510644 0.80290264 1.21132803 0.75697255
		 1.37048638 0.76756811 1.40198755 0.73591399 1.40608072 0.80248338 1.33669472 0.80529034
		 1.34777355 0.70864284 1.38681567 0.70608711 1.37113523 0.79783738 1.36662555 0.80362993
		 1.02927506 0.86875278 1.027414441 0.86004692 1.028731227 0.83866018 1.028149128 0.9167372
		 0.99986178 0.94847548 1.0097594261 0.9599939 1.022309661 0.87075663 1.019455791 0.91676509
		 0.79110438 0.44141054 0.79635751 0.44993693 0.7864849 0.44876048 0.77220857 0.4877564
		 0.62542653 0.53466761 0.60376412 0.52502382 0.61484486 0.58211815 0.61029494 0.57247436
		 0.60798407 0.68123007 0.59439927 0.636527 0.56966746 0.68771857 0.5651176 0.67807484
		 0.56964129 0.36720118 0.58895183 0.31190187 0.5977627 0.35274532 0.58913279 0.37246531
		 0.76306647 0.41141412 0.75759411 0.42219609 0.75969666 0.53096861 0.74187702 0.54175055
		 0.74669272 0.62842375 0.72491693 0.63920575 0.75744385 0.63973129 0.73447067 0.6875577
		 0.54880977 0.055609893 0.54015857 0.098246299 0.5314303 0.047856972 0.5107314 0.059397943
		 0.50804436 0.16390267 0.48513159 0.13845013 0.48121592 0.19009075 0.47223979 0.18585055
		 0.46399295 0.30939046 0.43083635 0.26865101 0.44173938 0.28244206 0.42829528 0.278202
		 0.41131905 0.35977277 0.384776 0.31031814 0.49965763 -0.017881818 0.48486775 -0.059380043
		 0.14627218 -0.70510685 0.13558441 -0.68060356 0.16333276 -0.63360387 0.14977628 -0.60910058
		 0.17023182 -0.54970413 0.15551531 -0.54562211 0.19686872 -0.46690369 0.17767316 -0.46282166
		 0.19686872 -0.41652739 0.17767316 -0.4124454 0.22230685 -0.33919671 0.198834 -0.33511472
		 -0.10330769 0.22833598 -0.1180242 0.23299444 -0.14466107 0.15019393 -0.12546557 0.14553559
		 -0.14466107 0.099817634 -0.12546557 0.095159233 -0.17009927 0.022486925 -0.14662637
		 0.017828584 -0.047372572 0.28987616 -0.062089078 0.2852177 0.80194551 0.15480244
		 0.821141 0.16043931 -0.039931171 0.15204096 -0.01490913 0.15669936 -0.012943819 0.07471031
		 0.010529056 0.078390121 0.74744588 -0.22521967 0.74744588 -0.20808035 -0.13292557
		 -0.16002685 0.64700294 -0.22022033 0.70574749 -0.21880311 0.28050923 -0.010466158
		 0.16146608 0.019622624 -0.20183811 -0.15170825 -0.21505781 -0.073345065 -0.23503412
		 -0.076682806 0.55754972 -0.046893954 0.53158355 -0.050231695 0.13231143 0.2336309
		 0.55059052 0.57470173 0.72578728 0.34778196 0.72392642 0.32158113 0.78710032 0.31789231
		 0.79112077 0.35609949 0.71413326 0.35876697 0.68426871 0.33042169 0.81846774 0.34366184
		 0.82401276 0.37017423 0.86133444 0.43269616 0.82534403 0.44122034 0.87038761 0.5111776
		 0.45358151 1.0090081692 0.46414238 1.077076197 0.44183308 1.044524431 0.7760219 1.26066399
		 0.76427346 1.2148118 0.81053329 1.21657014 0.79878485 1.16008759 0.7760219 1.13616514
		 0.79878485 1.064314485 0.82975817 1.092350364 0.81800973 1.027988791 0.7760219 0.97934663
		 1.15479445 0.73158735 1.18350208 0.75163901 1.19915318 0.80095339 1.17908716 0.81478918
		 1.11028695 0.79784709 1.15628576 0.80501252 1.17551064 0.87531114 1.17967439 0.89495361
		 1.17551064 0.92721856 1.17967439 0.93441373 1.18057847 0.98902333 0.85198814 1.045742273
		 0.81507069 1.22998941 0.80450755 1.25484264 0.79023123 1.19560623 1.0051941872 1.14502263
		 1.029452801 1.23200536 1.018889666 1.26747847 0.99463105 1.12513816 1.012213945 1.059473157
		 1.010209918 0.9977833 1.030240536 0.98958242 1.12111783 0.83068246 1.13168097 0.86522233
		 1.091669559 0.86624753 1.084845543 0.86625558 1.11979818 0.92884099 1.1157316 0.93128294
		 1.12299335 0.99633652 1.11515749 0.99633688 0.47359708 1.37121272 0.47370073 1.34493065
		 0.50481975 1.34135628 0.50317413 1.37655497 0.6268903 1.34802151 0.61367929 1.34298658
		 0.63239044 1.34038401 0.64673722 1.35607374 0.63089967 1.43151641 0.62099254 1.46322536
		 0.62535852 1.5125854 0.61243623 1.48647952 0.61922324 1.54430497 0.58033472 1.54713726
		 0.6103819 1.58123136 0.62054628 1.58417082 0.93227303 0.79701251 0.9062717 0.82446724
		 0.88301021 0.79765624 0.88115877 0.79906315 0.64077657 1.38322699 0.64605165 1.3761704
		 0.65921283 1.40190303 0.6283505 1.38520992 0.81113553 1.38535929 0.80185068 1.41697311
		 0.77117813 1.47128177 0.75906742 1.43379498 0.73906738 1.50591755 0.72696245 1.46881866
		 0.76588285 1.53526568 0.75046927 1.56630409 1.31877089 1.3782599 1.33524084 1.39540708
		 1.30103707 1.35755634 1.30210102 1.33776903 1.35571814 1.41513145 1.34609699 1.43495643
		 1.25372314 1.27385736 1.28385878 1.29333782 1.29071832 1.28895676 1.29637122 1.28569245
		 1.2671783 1.20019603 1.31713474 1.31015575 1.28739858 1.22995257 1.28384459 1.15875173
		 1.011437416 0.98230559 1.045739889 0.8296687 1.088916779 0.76741916 1.10714233 0.79335743
		 1.081728697 0.73760581 1.13887382 0.71802878 1.12229562 0.67345798 1.11063886 0.69106716
		 0.48954234 0.62172592;
	setAttr ".uvst[0].uvsp[500:572]" 0.51308239 0.62172592 0.49951068 0.66604722
		 0.48954234 0.66604722 0.51308239 0.66604722 0.49144807 0.7263459 0.47874698 0.7263459
		 0.50874102 0.7263459 0.36124018 0.73239589 0.32672879 0.73239589 0.34488836 0.70964384
		 0.35846016 0.70964384 0.36186066 0.69522059 0.37543252 0.69522059 0.38658789 0.73239589
		 1.19561338 0.70610136 1.18525267 0.62860268 1.2173605 0.64080596 1.22617853 0.67919761
		 1.12744308 0.5659517 1.14462471 0.55741322 1.16137743 0.64042777 1.17597318 0.57815498
		 0.75633264 0.65005749 0.72182125 0.65005749 0.72460121 0.62730545 0.73817307 0.62730545
		 0.69647342 0.65005749 0.71463305 0.62730545 0.70762897 0.6128822 0.72120076 0.6128822
		 0.69766068 0.6128822 0.70762897 0.56856084 0.72120076 0.56856084 0.69766068 0.56856084
		 0.69956642 0.50826228 0.71685928 0.50826228 0.68686533 0.50826228 0.74116373 0.77795136
		 0.70369905 0.77236116 0.71581042 0.77497691 1.24235606 0.77616668 1.36480093 0.76609141
		 1.0041265488 0.93812168 1.017405033 0.91552675 1.3901298 0.79719293 1.23249018 0.77844465
		 0.99586773 0.9495095 1.030676961 0.91789591 1.37499464 0.81863689 1.38990128 0.79639935
		 1.003341198 0.94182277 1.016331434 0.87162536 1.35977972 0.79813415 1.025839806 0.86319953
		 1.27104974 0.78365874 1.27528572 0.78165293 1.37871885 0.80086166 1.36669505 0.80447757
		 0.59878093 0.35921314 0.79511219 1.022772789 0.56979024 0.36804402 0.70852691 0.74739099
		 0.70000273 0.77236116 0.83433396 1.044923306 0.51352483 0.15326682 1.08743 0.72951186
		 1.083714366 0.74072254 1.090541124 0.74110019 1.084683418 0.7424891 0.88756061 0.77418995
		 0.8477062 0.75267935 0.48659468 0.14403056 0.44480905 0.16037485;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".clst[0].clsn" -type "string" "SculptFreezeColorTemp";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 254 ".vt";
	setAttr ".vt[0:165]"  -0.5 -0.5 0.5 0.5 -0.5 0.5 -0.49532115 0.28230757 0.5074259
		 0.49532104 0.28230757 0.5074259 -0.43430114 0.47992593 -0.27252436 0.44539714 0.466654 -0.25478745
		 -0.5 -0.5 -0.5 0.5 -0.5 -0.5 -0.20694089 0.53816909 -0.30284166 -0.31007385 -0.5 -0.5
		 -0.31007385 -0.5 0.5 -0.31007385 0.42310113 0.5074259 0.32535505 0.42310113 0.5074259
		 0.24606037 0.544954 -0.30284166 0.32535505 -0.5 -0.5 0.32535505 -0.5 0.5 0.42100406 0.21488577 0.53997856
		 0.27395153 0.21488577 0.53997856 -0.26108479 0.21488577 0.53997856 -0.42100406 0.21488577 0.53997856
		 -0.36028266 0.29634184 -0.42506993 -0.20694089 0.29634184 -0.52247906 0.24606037 0.29634184 -0.52247906
		 0.40479517 0.29634184 -0.3871398 0.40485859 -0.04087472 0.5 0.26344538 -0.04087472 0.5
		 -0.25107217 -0.04087472 0.5 -0.40485859 -0.04087472 0.5 -0.5 -0.04087472 -0.45994341
		 -0.31007385 -0.04087472 -0.5882405 0.32535505 -0.04087472 -0.5882405 0.5 -0.04087472 -0.44480157
		 0.5043931 0.456572 0.10727417 0.32535505 0.55873102 0.10727417 -0.31007385 0.55873102 0.10727417
		 -0.5043931 0.456572 0.10727417 -0.5 0.29634184 0.10727417 -0.5 -0.04087472 0.10727417
		 -0.5 -0.5 0.10727417 -0.31007385 -0.5 0.10727417 0.32535505 -0.5 0.10727417 0.5 -0.5 0.10727417
		 0.5 -0.04087472 0.10727417 0.5 0.29634184 0.10727417 0.49905396 0.35906607 0.32227039
		 0.32535505 0.54057032 0.32227039 -0.31007385 0.54057032 0.32227039 -0.49905407 0.35906607 0.32227039
		 -0.5 0.29634184 0.32227039 -0.5 -0.04087472 0.32227039 -0.5 -0.5 0.32227039 -0.31007385 -0.5 0.32227039
		 0.32535505 -0.5 0.32227039 0.5 -0.5 0.32227039 0.5 -0.04087472 0.32227039 0.5 0.29634184 0.32227039
		 0.023133039 0.49673861 -0.30284166 0.023133039 0.29634184 -0.52247906 0.012652874 -0.04087472 -0.67762542
		 0.012652874 -0.5 -0.33077335 0.012652874 -0.5 0.10727417 0.012652874 -0.5 0.32227039
		 0.012652874 -0.5 0.5 0.012652874 -0.04087472 0.5 0.012652874 0.21488577 0.53997856
		 0.012652874 0.42310113 0.5074259 0.012652874 0.54057032 0.32227039 0.012652874 0.55873102 0.10727417
		 -0.5 -0.04087472 -1.063034296 -0.31007385 -0.04087472 -1.19133139 -0.31007385 -0.5 -1.103091
		 -0.5 -0.5 -1.103091 0.32535505 -0.04087472 -1.19133139 0.32535505 -0.5 -1.103091
		 0.5 -0.04087472 -1.04789257 0.5 -0.5 -1.103091 -0.5 0.33677715 -1.70174575 -0.31007385 0.33677715 -1.83004284
		 -0.31007385 0.092992127 -1.74180245 -0.5 0.092992127 -1.74180245 0.32535505 0.33677715 -1.83004284
		 0.32535505 0.092992127 -1.74180245 0.5 0.33677715 -1.68660402 0.5 0.092992127 -1.74180245
		 -0.5 0.43049449 -2.79942417 -0.31007385 0.43049449 -2.92772102 -0.31007385 0.18670946 -2.83948088
		 -0.5 0.18670946 -2.83948088 0.32535505 0.43049449 -2.92772102 0.32535505 0.18670946 -2.83948088
		 0.5 0.43049449 -2.78428221 0.5 0.18670946 -2.83948088 -0.5 -0.27279127 -3.6515522
		 -0.31007385 -0.27279127 -3.77984905 -0.31007385 -0.51657629 -3.69160938 -0.5 -0.51657629 -3.69160938
		 0.32535505 -0.27279127 -3.77984905 0.32535505 -0.51657629 -3.69160938 0.5 -0.27279127 -3.63641071
		 0.5 -0.51657629 -3.69160938 -0.5 -0.54197544 -4.73918295 -0.31007385 -0.54197544 -4.8674798
		 -0.31007385 -0.78576046 -4.77924013 -0.5 -0.78576046 -4.77924013 0.32535505 -0.54197544 -4.8674798
		 0.32535505 -0.78576046 -4.77924013 0.5 -0.54197544 -4.72404146 0.5 -0.78576046 -4.77924013
		 -0.70340967 -0.5 -0.31514001 -0.84559536 -0.5 0.056878924 -0.84559536 -0.04087472 0.056878924
		 -0.70340967 -0.04087472 -0.28173161 0.84559536 -0.5 0.056878924 0.84559536 -0.04087472 0.056878924
		 0.70340967 -0.5 -0.31514001 0.70340967 -0.04087472 -0.26910293 -0.89221168 -0.41453147 -1.26638556
		 -1.072561383 -0.41453147 -0.89436674 -1.072561383 0.044593811 -0.89436674 -0.89221168 0.044593811 -1.23297715
		 1.072561264 -0.41453147 -0.89436674 1.072561264 0.044593811 -0.89436674 0.89221168 -0.41453147 -1.26638556
		 0.89221168 0.044593811 -1.22034836 -0.96856129 0.28924555 -2.072508574 -1.16434407 0.28924555 -2.010534763
		 -1.16434407 0.67496938 -2.010534763 -0.96856129 0.67496938 -2.066943884 1.16434383 0.28924555 -2.010534763
		 1.16434383 0.67496938 -2.010534763 0.96856117 0.28924555 -2.072508574 0.96856117 0.67496938 -2.064840078
		 -1.26334083 0.28924555 -3.17405128 -1.51870966 0.28924555 -3.11207771 -1.51870966 0.67496938 -3.11207771
		 -1.26334083 0.67496938 -3.1684866 1.51870942 0.28924555 -3.11207771 1.51870942 0.67496938 -3.11207771
		 1.26334071 0.28924555 -3.17405128 1.26334071 0.67496938 -3.16638279 -1.26334083 -0.3923378 -3.84423733
		 -1.51870966 -0.3923378 -3.78226376 -1.51870966 -0.0066139698 -3.78226376 -1.26334083 -0.0066139698 -3.83867264
		 1.51870942 -0.3923378 -3.78226376 1.51870942 -0.0066139698 -3.78226376 1.26334071 -0.3923378 -3.84423733
		 1.26334071 -0.0066139698 -3.83656883 -1.54485548 -0.67077482 -4.87301302 -1.8571291 -0.67077482 -4.81103945
		 -1.8571291 -0.28505105 -4.81103945 -1.54485548 -0.28505105 -4.86744833 1.85712886 -0.67077482 -4.81103945
		 1.85712886 -0.28505105 -4.81103945 1.54485536 -0.67077482 -4.87301302 1.54485536 -0.28505105 -4.86534452
		 -0.80268407 -0.077858388 0.32227039 -0.80268407 -0.077858388 0.10727417 -0.80268407 0.054754317 0.32227039
		 -0.80268407 0.054754317 0.10727417 -0.80268407 -0.25841248 0.10727417 -0.80268407 -0.25841248 0.32227039
		 0.80268407 -0.25841248 0.32227039 0.80268407 -0.077858388 0.32227039 0.80268407 -0.25841248 0.10727417
		 0.80268407 -0.077858388 0.10727417;
	setAttr ".vt[166:253]" 0.80268407 0.054754317 0.32227039 0.80268407 0.054754317 0.10727417
		 -0.99456525 0.14793414 0.32227039 -0.99456525 0.14793414 0.10727417 -0.99456525 0.28054684 0.32227039
		 -0.99456525 0.28054684 0.10727417 -0.99456525 -0.032619894 0.10727417 -0.99456525 -0.032619894 0.32227039
		 0.99456525 -0.032619894 0.32227039 0.99456525 0.14793414 0.32227039 0.99456525 -0.032619894 0.10727417
		 0.99456525 0.14793414 0.10727417 0.99456525 0.28054684 0.32227039 0.99456525 0.28054684 0.10727417
		 -1.58419824 0.14793414 0.3411243 -1.58419824 0.14793414 0.088420272 -1.58419824 0.28054684 0.3411243
		 -1.58419824 0.28054684 0.088420272 -1.58419824 -0.032619894 0.088420272 -1.58419824 -0.032619894 0.3411243
		 1.58419824 -0.032619894 0.3411243 1.58419824 0.14793414 0.3411243 1.58419824 -0.032619894 0.088420272
		 1.58419824 0.14793414 0.088420272 1.58419824 0.28054684 0.3411243 1.58419824 0.28054684 0.088420272
		 -2.50098228 0.25519305 -0.022246292 -2.38638568 0.25519305 -0.27999744 -2.50098228 0.42416424 -0.022246292
		 -2.38638568 0.42416424 -0.27999744 -2.38638568 0.025136426 -0.27999744 -2.50098228 0.025136426 -0.022246292
		 2.50483036 0.025136426 -0.022246292 2.50483036 0.25519305 -0.022246292 2.38638544 0.025136426 -0.27999744
		 2.38638544 0.25519305 -0.27999744 2.50483036 0.42416424 -0.022246292 2.38638544 0.42416424 -0.27999744
		 -2.94260859 0.24338898 -1.020354033 -2.67685199 0.24338898 -1.064758301 -2.94260859 0.46589762 -1.020354033
		 -2.67685199 0.46589762 -1.064758301 -2.67685199 0.1022439 -1.064758301 -2.94260859 0.1022439 -1.020354033
		 2.92805672 0.1022439 -1.020354033 2.92805672 0.24338898 -1.020354033 2.71265984 0.1022439 -1.084611297
		 2.71265984 0.24338898 -1.084611297 2.92805672 0.46589762 -1.020354033 2.71265984 0.46589762 -1.084611297
		 -3.11968994 -0.76957583 -1.92033422 -2.77424693 -0.76957583 -1.96473849 -3.11968994 -0.54706722 -1.92033422
		 -2.77424693 -0.54706722 -1.96473849 -2.77424693 -0.91072094 -1.96473849 -3.11968994 -0.91072094 -1.92033422
		 3.11968946 -0.91072094 -1.92033422 3.11968946 -0.6507349 -1.92033422 2.82289529 -0.91072094 -1.98459125
		 2.82289529 -0.76957583 -1.98459125 3.11968946 -0.54706722 -1.92033422 2.82289529 -0.54706722 -1.98459125
		 -3.11968994 -0.76957583 -2.91706944 -2.77424693 -0.76957583 -2.96147394 -3.11968994 -0.54706722 -2.91706944
		 -2.77424693 -0.54706722 -2.96147394 -2.77424693 -0.91072094 -2.96147394 -3.11968994 -0.91072094 -2.91706944
		 3.11968946 -0.91072094 -2.91706944 3.11968946 -0.6507349 -2.91706944 2.82289529 -0.91072094 -2.98132634
		 2.82289529 -0.76957583 -2.98132634 3.11968946 -0.54706722 -2.91706944 2.82289529 -0.54706722 -2.98132634
		 -0.10281886 0.29634184 -0.52247906 -0.20694089 0.42403728 -0.40650085 -0.28373599 0.29634184 -0.47369564
		 0.35060897 0.29634184 -0.4333396 0.24606037 0.41150022 -0.42074192 0.16727072 0.29634184 -0.52247906
		 -0.20694089 0.32599258 -0.49554902 -0.24711971 0.29634184 -0.49695581 -0.15719679 0.29634184 -0.52247906
		 0.24606037 0.32686156 -0.49551627 0.20977843 0.29634184 -0.52247906 0.28629571 0.29634184 -0.4881739
		 -0.2166855 0.26447964 -0.5286926 0.2536985 0.26385924 -0.5288136;
	setAttr -s 502 ".ed";
	setAttr ".ed[0:165]"  0 10 0 2 11 0 4 8 0 6 9 0 0 27 0 1 24 0 2 47 0 3 44 0
		 4 20 0 5 23 0 6 38 0 7 41 0 8 56 0 9 59 0 8 241 1 10 62 0 9 39 1 11 65 0 10 26 1
		 11 46 1 12 3 0 13 5 0 12 45 1 14 7 0 13 244 1 15 1 0 14 40 1 15 25 1 16 3 0 17 12 1
		 16 17 1 18 11 1 17 64 1 19 2 0 18 19 1 20 28 0 19 48 1 21 252 1 20 242 1 22 253 1
		 21 248 1 23 31 0 22 251 1 23 43 1 24 16 0 25 17 1 24 25 1 26 18 1 25 63 1 27 19 0
		 26 27 1 28 6 0 27 49 1 29 9 0 28 29 0 30 14 0 29 58 1 31 7 0 30 31 0 31 42 0 32 5 0
		 33 13 1 32 33 1 34 8 1 33 67 1 35 4 0 34 35 1 36 20 1 35 36 1 37 28 0 36 37 0 38 50 0
		 37 38 0 39 51 1 38 39 1 40 52 1 39 60 1 41 53 0 40 41 1 41 42 0 43 55 0 42 43 0 43 32 1
		 44 32 0 45 33 1 44 45 1 46 34 1 45 66 1 47 35 0 46 47 1 48 36 0 47 48 1 48 49 0 50 0 0
		 49 50 0 51 10 1 50 51 1 52 15 1 51 61 1 53 1 0 52 53 1 54 24 1 53 54 0 55 16 1 54 55 0
		 55 44 1 56 13 0 57 245 1 56 57 1 58 30 1 57 58 1 59 14 0 58 59 1 60 40 1 59 60 1
		 61 52 1 60 61 1 62 15 0 61 62 1 63 26 1 62 63 1 64 18 1 63 64 1 65 12 0 64 65 1 66 46 1
		 65 66 1 67 34 1 66 67 1 67 56 1 28 68 0 29 69 0 68 69 0 9 70 0 69 70 0 6 71 0 71 70 0
		 68 71 0 30 72 0 14 73 0 72 73 0 31 74 0 72 74 0 7 75 0 74 75 0 73 75 0 68 76 0 69 77 0
		 76 77 0 70 78 0 77 78 0 71 79 0 79 78 0 76 79 0 72 80 0 73 81 0 80 81 0 74 82 0 80 82 0
		 75 83 0 82 83 0 81 83 0 76 84 0 77 85 0 84 85 0 78 86 0;
	setAttr ".ed[166:331]" 85 86 0 79 87 0 87 86 0 84 87 0 80 88 0 81 89 0 88 89 0
		 82 90 0 88 90 0 83 91 0 90 91 0 89 91 0 84 92 0 85 93 0 92 93 0 86 94 0 93 94 0 87 95 0
		 95 94 0 92 95 0 88 96 0 89 97 0 96 97 0 90 98 0 96 98 0 91 99 0 98 99 0 97 99 0 92 100 0
		 93 101 0 100 101 0 94 102 0 101 102 0 95 103 0 103 102 0 100 103 0 96 104 0 97 105 0
		 104 105 0 98 106 0 104 106 0 99 107 0 106 107 0 105 107 0 6 108 0 38 109 0 108 109 0
		 37 110 0 110 109 0 28 111 0 110 111 0 111 108 0 41 112 0 42 113 0 112 113 0 7 114 0
		 114 112 0 31 115 0 115 114 0 115 113 0 108 116 0 109 117 0 116 117 0 110 118 0 118 117 0
		 111 119 0 118 119 0 119 116 0 112 120 0 113 121 0 120 121 0 114 122 0 122 120 0 115 123 0
		 123 122 0 123 121 0 116 124 0 117 125 0 124 125 0 118 126 0 126 125 0 119 127 0 126 127 0
		 127 124 0 120 128 0 121 129 0 128 129 0 122 130 0 130 128 0 123 131 0 131 130 0 131 129 0
		 124 132 0 125 133 0 132 133 0 126 134 0 134 133 0 127 135 0 134 135 0 135 132 0 128 136 0
		 129 137 0 136 137 0 130 138 0 138 136 0 131 139 0 139 138 0 139 137 0 132 140 0 133 141 0
		 140 141 0 134 142 0 142 141 0 135 143 0 142 143 0 143 140 0 136 144 0 137 145 0 144 145 0
		 138 146 0 146 144 0 139 147 0 147 146 0 147 145 0 140 148 0 141 149 0 148 149 0 142 150 0
		 150 149 0 143 151 0 150 151 0 151 148 0 144 152 0 145 153 0 152 153 0 146 154 0 154 152 0
		 147 155 0 155 154 0 155 153 0 49 156 0 37 157 0 48 158 0 158 156 0 36 159 0 158 159 0
		 159 157 0 38 160 0 50 161 0 160 161 0 156 161 0 157 160 0 53 162 0 54 163 0 162 163 0
		 41 164 0 164 162 0 42 165 0 164 165 0 55 166 0 163 166 0 43 167 0 165 167 0 167 166 0
		 156 168 0 157 169 0;
	setAttr ".ed[332:497]" 158 170 0 170 168 0 159 171 0 170 171 0 171 169 0 160 172 0
		 161 173 0 172 173 0 168 173 0 169 172 0 162 174 0 163 175 0 174 175 0 164 176 0 176 174 0
		 165 177 0 176 177 0 166 178 0 175 178 0 167 179 0 177 179 0 179 178 0 168 180 0 169 181 0
		 170 182 0 182 180 0 171 183 0 182 183 0 183 181 0 172 184 0 173 185 0 184 185 0 180 185 0
		 181 184 0 174 186 0 175 187 0 186 187 0 176 188 0 188 186 0 177 189 0 188 189 0 178 190 0
		 187 190 0 179 191 0 189 191 0 191 190 0 180 192 0 181 193 0 182 194 0 194 192 0 183 195 0
		 194 195 0 195 193 0 184 196 0 185 197 0 196 197 0 192 197 0 193 196 0 186 198 0 187 199 0
		 198 199 0 188 200 0 200 198 0 189 201 0 200 201 0 190 202 0 199 202 0 191 203 0 201 203 0
		 203 202 0 192 204 0 193 205 0 194 206 0 206 204 0 195 207 0 206 207 0 207 205 0 196 208 0
		 197 209 0 208 209 0 204 209 0 205 208 0 198 210 0 199 211 0 210 211 0 200 212 0 212 210 0
		 201 213 0 212 213 0 202 214 0 211 214 0 203 215 0 213 215 0 215 214 0 204 216 0 205 217 0
		 206 218 0 218 216 0 207 219 0 218 219 0 219 217 0 208 220 0 209 221 0 220 221 0 216 221 0
		 217 220 0 210 222 0 211 223 0 222 223 0 212 224 0 224 222 0 213 225 0 224 225 0 214 226 0
		 223 226 0 215 227 0 225 227 0 227 226 0 216 228 0 217 229 0 228 229 1 218 230 0 230 228 0
		 219 231 0 230 231 0 231 229 0 220 232 0 221 233 0 232 233 0 228 233 0 229 232 0 222 234 0
		 223 235 0 234 235 0 224 236 0 236 234 0 225 237 0 236 237 0 237 235 1 226 238 0 235 238 0
		 227 239 0 237 239 0 239 238 0 240 57 1 241 246 1 242 247 1 240 241 1 241 242 1 243 23 1
		 244 249 1 245 250 1 243 244 1 244 245 1 246 21 1 247 21 1 246 247 1 248 240 1 246 248 1
		 249 22 1 250 22 1 249 250 1 251 243 1 249 251 1 252 29 1 240 252 1;
	setAttr ".ed[498:501]" 252 242 1 253 30 1 243 253 1 253 245 1;
	setAttr -s 250 -ch 1004 ".fc[0:249]" -type "polyFaces" 
		f 4 0 18 50 -5
		mu 0 4 406 407 408 409
		f 4 1 19 89 -7
		mu 0 4 32 34 35 33
		f 4 196 198 -201 -202
		mu 0 4 426 427 428 429
		f 4 96 95 -1 -94
		mu 0 4 202 203 204 205
		f 4 -100 102 101 -6
		mu 0 4 0 1 2 3
		f 4 93 4 52 94
		mu 0 4 26 27 28 29
		f 4 56 112 -14 -54
		mu 0 4 430 431 432 433
		f 4 -96 98 118 -16
		mu 0 4 204 203 208 209
		f 4 -19 15 120 119
		mu 0 4 408 407 410 411
		f 4 -20 17 126 125
		mu 0 4 295 304 298 289
		f 4 -23 20 7 85
		mu 0 4 10 11 7 6
		f 4 -205 206 208 -210
		mu 0 4 445 446 447 448
		f 4 -98 100 99 -26
		mu 0 4 216 215 225 226
		f 4 -28 25 5 46
		mu 0 4 415 414 419 420
		f 4 -30 -31 28 -21
		mu 0 4 424 421 423 425
		f 4 -32 -122 124 -18
		mu 0 4 417 412 416 422
		f 4 -35 31 -2 -34
		mu 0 4 413 412 417 418
		f 4 -37 33 6 91
		mu 0 4 31 30 32 33
		f 5 2 14 480 -39 -9
		mu 0 5 294 540 552 553 303
		f 5 12 108 -477 479 -15
		mu 0 5 545 537 292 296 549
		f 5 -482 484 -25 21 9
		mu 0 5 284 285 554 278 539
		f 4 -104 105 -8 -29
		mu 0 4 572 571 6 7
		f 4 -46 -47 44 30
		mu 0 4 421 415 420 423
		f 4 -48 -120 122 121
		mu 0 4 412 408 411 416
		f 4 -51 47 34 -50
		mu 0 4 409 408 412 413
		f 4 -53 49 36 92
		mu 0 4 29 28 30 31
		f 4 498 478 487 37
		mu 0 4 46 45 48 49
		f 4 40 489 497 -38
		mu 0 4 439 440 435 434
		f 4 500 -40 42 494
		mu 0 4 21 20 22 568
		f 4 -102 104 103 -45
		mu 0 4 3 2 4 5
		f 4 -62 -63 60 -22
		mu 0 4 538 561 280 281
		f 4 -64 -128 129 -13
		mu 0 4 287 288 283 282
		f 4 -67 63 -3 -66
		mu 0 4 293 288 287 541
		f 4 -68 -69 65 8
		mu 0 4 41 36 37 42
		f 4 -70 -71 67 35
		mu 0 4 43 44 36 41
		f 4 292 -295 296 297
		mu 0 4 449 450 451 452
		f 4 3 16 -75 -11
		mu 0 4 210 211 207 206
		f 4 -77 -17 13 114
		mu 0 4 212 207 211 219
		f 4 -79 -27 23 11
		mu 0 4 232 222 229 237
		f 4 -301 -303 -305 305
		mu 0 4 453 454 455 456
		f 4 -82 -60 -42 43
		mu 0 4 8 17 18 14
		f 4 -83 -44 -10 -61
		mu 0 4 9 8 14 15
		f 4 -85 -86 83 62
		mu 0 4 16 10 6 9
		f 4 -87 -126 128 127
		mu 0 4 288 295 289 283
		f 4 -90 86 66 -89
		mu 0 4 33 35 38 37
		f 4 -91 -92 88 68
		mu 0 4 36 31 33 37
		f 4 -453 -455 456 457
		mu 0 4 457 458 459 460
		f 4 460 -462 452 462
		mu 0 4 461 462 458 457
		f 4 74 73 -97 -72
		mu 0 4 206 207 203 202
		f 4 -99 -74 76 116
		mu 0 4 208 203 207 212
		f 4 -101 -76 78 77
		mu 0 4 225 215 222 232
		f 4 -466 -468 469 470
		mu 0 4 463 464 465 466
		f 4 -473 -471 474 475
		mu 0 4 467 463 466 468
		f 4 -106 -81 82 -84
		mu 0 4 6 571 8 9
		f 5 106 24 485 -108 -109
		mu 0 5 537 278 554 555 292
		f 4 501 483 492 39
		mu 0 4 442 441 443 444
		f 4 -113 109 55 -112
		mu 0 4 432 431 437 438
		f 4 -114 -115 111 26
		mu 0 4 222 212 219 229
		f 4 -116 -117 113 75
		mu 0 4 215 208 212 222
		f 4 -119 115 97 -118
		mu 0 4 209 208 215 216
		f 4 -121 117 27 48
		mu 0 4 411 410 414 415
		f 4 -123 -49 45 32
		mu 0 4 416 411 415 421
		f 4 -125 -33 29 -124
		mu 0 4 422 416 421 424
		f 4 -127 123 22 87
		mu 0 4 289 298 299 290
		f 4 -129 -88 84 64
		mu 0 4 283 289 290 279
		f 4 -130 -65 61 -107
		mu 0 4 282 283 279 562
		f 4 54 131 -133 -131
		mu 0 4 310 311 312 313
		f 4 53 133 -135 -132
		mu 0 4 50 51 52 53
		f 4 -4 135 136 -134
		mu 0 4 211 210 217 218
		f 4 -52 130 137 -136
		mu 0 4 62 63 64 65
		f 4 -56 138 140 -140
		mu 0 4 76 77 78 79
		f 4 58 141 -143 -139
		mu 0 4 322 323 324 560
		f 4 57 143 -145 -142
		mu 0 4 88 559 90 569
		f 4 -24 139 145 -144
		mu 0 4 237 229 244 245
		f 4 132 147 -149 -147
		mu 0 4 313 312 314 315
		f 4 134 149 -151 -148
		mu 0 4 53 52 54 55
		f 4 -137 151 152 -150
		mu 0 4 218 217 227 228
		f 4 -138 146 153 -152
		mu 0 4 65 64 68 69
		f 4 -141 154 156 -156
		mu 0 4 79 78 80 81
		f 4 142 157 -159 -155
		mu 0 4 325 558 326 327
		f 4 144 159 -161 -158
		mu 0 4 91 570 94 95
		f 4 -146 155 161 -160
		mu 0 4 245 244 254 255
		f 4 148 163 -165 -163
		mu 0 4 315 314 316 317
		f 4 150 165 -167 -164
		mu 0 4 55 54 56 57
		f 4 -153 167 168 -166
		mu 0 4 228 227 235 236
		f 4 -154 162 169 -168
		mu 0 4 69 68 70 71
		f 4 -157 170 172 -172
		mu 0 4 81 80 82 83
		f 4 158 173 -175 -171
		mu 0 4 327 326 328 329
		f 4 160 175 -177 -174
		mu 0 4 95 94 96 97
		f 4 -162 171 177 -176
		mu 0 4 255 254 262 263
		f 4 164 179 -181 -179
		mu 0 4 317 316 318 319
		f 4 166 181 -183 -180
		mu 0 4 57 56 58 59
		f 4 -169 183 184 -182
		mu 0 4 236 235 242 243
		f 4 -170 178 185 -184
		mu 0 4 71 70 72 73
		f 4 -173 186 188 -188
		mu 0 4 83 82 84 85
		f 4 174 189 -191 -187
		mu 0 4 329 328 330 331
		f 4 176 191 -193 -190
		mu 0 4 97 96 98 99
		f 4 -178 187 193 -192
		mu 0 4 263 262 268 269
		f 4 180 195 -197 -195
		mu 0 4 319 318 320 321
		f 4 182 197 -199 -196
		mu 0 4 59 58 60 61
		f 4 -185 199 200 -198
		mu 0 4 243 242 252 253
		f 4 -186 194 201 -200
		mu 0 4 73 72 74 75
		f 4 -189 202 204 -204
		mu 0 4 85 84 86 87
		f 4 190 205 -207 -203
		mu 0 4 331 330 332 333
		f 4 192 207 -209 -206
		mu 0 4 99 98 100 101
		f 4 -194 203 209 -208
		mu 0 4 269 268 272 273
		f 4 10 211 -213 -211
		mu 0 4 210 206 220 221
		f 4 -73 213 214 -212
		mu 0 4 469 470 471 472
		f 4 69 215 -217 -214
		mu 0 4 334 335 336 337
		f 4 51 210 -218 -216
		mu 0 4 63 62 66 67
		f 4 -80 218 220 -220
		mu 0 4 473 474 475 476
		f 4 -12 221 222 -219
		mu 0 4 232 237 246 247
		f 4 -58 223 224 -222
		mu 0 4 89 563 92 93
		f 4 59 219 -226 -224
		mu 0 4 348 349 350 351
		f 4 212 227 -229 -227
		mu 0 4 221 220 230 231
		f 4 -215 229 230 -228
		mu 0 4 102 103 104 105
		f 4 216 231 -233 -230
		mu 0 4 337 336 338 339
		f 4 217 226 -234 -232
		mu 0 4 116 117 118 119
		f 4 -221 234 236 -236
		mu 0 4 128 129 130 131
		f 4 -223 237 238 -235
		mu 0 4 247 246 256 257
		f 4 -225 239 240 -238
		mu 0 4 142 143 144 145
		f 4 225 235 -242 -240
		mu 0 4 351 350 352 353
		f 4 228 243 -245 -243
		mu 0 4 110 105 107 111
		f 4 -231 245 246 -244
		mu 0 4 105 104 106 107
		f 4 232 247 -249 -246
		mu 0 4 339 338 340 341
		f 4 233 242 -250 -248
		mu 0 4 119 118 120 121
		f 4 -237 250 252 -252
		mu 0 4 131 130 132 133
		f 4 -239 253 254 -251
		mu 0 4 130 134 135 132
		f 4 -241 255 256 -254
		mu 0 4 145 144 146 147
		f 4 241 251 -258 -256
		mu 0 4 353 352 354 355
		f 4 244 259 -261 -259
		mu 0 4 362 363 364 365
		f 4 -247 261 262 -260
		mu 0 4 107 106 108 109
		f 4 248 263 -265 -262
		mu 0 4 341 340 342 343
		f 4 249 258 -266 -264
		mu 0 4 121 120 122 123
		f 4 -253 266 268 -268
		mu 0 4 133 132 136 137
		f 4 -255 269 270 -267
		mu 0 4 370 371 372 373
		f 4 -257 271 272 -270
		mu 0 4 147 146 148 149
		f 4 257 267 -274 -272
		mu 0 4 355 354 356 357
		f 4 260 275 -277 -275
		mu 0 4 365 364 366 367
		f 4 -263 277 278 -276
		mu 0 4 109 108 112 113
		f 4 264 279 -281 -278
		mu 0 4 343 342 344 345
		f 4 265 274 -282 -280
		mu 0 4 123 122 124 125
		f 4 -269 282 284 -284
		mu 0 4 137 136 138 139
		f 4 -271 285 286 -283
		mu 0 4 373 372 374 375
		f 4 -273 287 288 -286
		mu 0 4 149 148 150 151
		f 4 273 283 -290 -288
		mu 0 4 357 356 358 359
		f 4 276 291 -293 -291
		mu 0 4 367 366 368 369
		f 4 -279 293 294 -292
		mu 0 4 113 112 114 115
		f 4 280 295 -297 -294
		mu 0 4 345 344 346 347
		f 4 281 290 -298 -296
		mu 0 4 125 124 126 127
		f 4 -285 298 300 -300
		mu 0 4 139 138 140 141
		f 4 -287 301 302 -299
		mu 0 4 375 374 376 377
		f 4 -289 303 304 -302
		mu 0 4 151 150 152 153
		f 4 289 299 -306 -304
		mu 0 4 359 358 360 361
		f 4 -93 308 309 -307
		mu 0 4 477 478 479 480
		f 4 90 310 -312 -309
		mu 0 4 31 36 39 40
		f 4 70 307 -313 -311
		mu 0 4 492 493 494 495
		f 4 71 314 -316 -314
		mu 0 4 206 202 213 214
		f 4 -95 306 316 -315
		mu 0 4 483 477 480 484
		f 4 72 313 -318 -308
		mu 0 4 493 496 497 494
		f 4 -103 318 320 -320
		mu 0 4 507 508 509 510
		f 4 -78 321 322 -319
		mu 0 4 225 232 238 239
		f 4 79 323 -325 -322
		mu 0 4 522 523 524 525
		f 4 -105 319 326 -326
		mu 0 4 513 507 510 514
		f 4 81 327 -329 -324
		mu 0 4 523 526 527 524
		f 4 80 325 -330 -328
		mu 0 4 8 571 12 13
		f 4 -310 332 333 -331
		mu 0 4 480 479 481 482
		f 4 311 334 -336 -333
		mu 0 4 382 383 379 378
		f 4 312 331 -337 -335
		mu 0 4 495 494 498 499
		f 4 315 338 -340 -338
		mu 0 4 214 213 223 224
		f 4 -317 330 340 -339
		mu 0 4 484 480 482 487
		f 4 317 337 -342 -332
		mu 0 4 494 497 500 498
		f 4 -321 342 344 -344
		mu 0 4 510 509 511 512
		f 4 -323 345 346 -343
		mu 0 4 239 238 248 249
		f 4 324 347 -349 -346
		mu 0 4 525 524 528 529
		f 4 -327 343 350 -350
		mu 0 4 514 510 512 517
		f 4 328 351 -353 -348
		mu 0 4 524 527 530 528
		f 4 329 349 -354 -352
		mu 0 4 396 397 393 392
		f 4 -334 356 357 -355
		mu 0 4 482 481 485 486
		f 4 335 358 -360 -357
		mu 0 4 378 379 380 381
		f 4 336 355 -361 -359
		mu 0 4 499 498 501 502
		f 4 339 362 -364 -362
		mu 0 4 224 223 233 234
		f 4 -341 354 364 -363
		mu 0 4 487 482 486 490
		f 4 341 361 -366 -356
		mu 0 4 498 500 503 501
		f 4 -345 366 368 -368
		mu 0 4 512 511 515 516
		f 4 -347 369 370 -367
		mu 0 4 249 248 258 259
		f 4 348 371 -373 -370
		mu 0 4 529 528 531 532
		f 4 -351 367 374 -374
		mu 0 4 517 512 516 520
		f 4 352 375 -377 -372
		mu 0 4 528 530 533 531
		f 4 353 373 -378 -376
		mu 0 4 392 393 394 395
		f 4 -358 380 381 -379
		mu 0 4 486 485 488 489
		f 4 359 382 -384 -381
		mu 0 4 381 380 384 385
		f 4 360 379 -385 -383
		mu 0 4 502 501 504 505
		f 4 363 386 -388 -386
		mu 0 4 234 233 240 241
		f 4 -365 378 388 -387
		mu 0 4 490 486 489 491
		f 4 365 385 -390 -380
		mu 0 4 501 503 506 504
		f 4 -369 390 392 -392
		mu 0 4 516 515 518 519
		f 4 -371 393 394 -391
		mu 0 4 259 258 264 265
		f 4 372 395 -397 -394
		mu 0 4 532 531 534 535
		f 4 -375 391 398 -398
		mu 0 4 520 516 519 521
		f 4 376 399 -401 -396
		mu 0 4 531 533 536 534
		f 4 377 397 -402 -400
		mu 0 4 395 394 398 399
		f 4 -382 404 405 -403
		mu 0 4 154 155 156 157
		f 4 383 406 -408 -405
		mu 0 4 385 384 386 387
		f 4 384 403 -409 -407
		mu 0 4 166 167 168 169
		f 4 387 410 -412 -410
		mu 0 4 241 240 250 251
		f 4 -389 402 412 -411
		mu 0 4 160 154 157 161
		f 4 389 409 -414 -404
		mu 0 4 167 170 171 168
		f 4 -393 414 416 -416
		mu 0 4 178 179 180 181
		f 4 -395 417 418 -415
		mu 0 4 265 264 270 271
		f 4 396 419 -421 -418
		mu 0 4 190 191 192 193
		f 4 -399 415 422 -422
		mu 0 4 184 178 181 185
		f 4 400 423 -425 -420
		mu 0 4 191 194 195 192
		f 4 401 421 -426 -424
		mu 0 4 399 398 400 401
		f 4 -406 428 429 -427
		mu 0 4 157 156 158 159
		f 4 407 430 -432 -429
		mu 0 4 387 386 388 389
		f 4 408 427 -433 -431
		mu 0 4 169 168 172 173
		f 4 411 434 -436 -434
		mu 0 4 251 250 260 261
		f 4 -413 426 436 -435
		mu 0 4 161 157 159 164
		f 4 413 433 -438 -428
		mu 0 4 168 171 174 172
		f 4 -417 438 440 -440
		mu 0 4 181 180 182 183
		f 4 -419 441 442 -439
		mu 0 4 271 270 274 275
		f 4 420 443 -445 -442
		mu 0 4 193 192 196 197
		f 4 -423 439 446 -446
		mu 0 4 185 181 183 188
		f 4 424 447 -449 -444
		mu 0 4 192 195 198 196
		f 4 425 445 -450 -448
		mu 0 4 401 400 402 403
		f 4 -430 453 454 -451
		mu 0 4 159 158 162 163
		f 4 431 455 -457 -454
		mu 0 4 389 388 390 391
		f 4 432 451 -458 -456
		mu 0 4 173 172 175 176
		f 4 435 459 -461 -459
		mu 0 4 261 260 266 267
		f 4 -437 450 461 -460
		mu 0 4 164 159 163 165
		f 4 437 458 -463 -452
		mu 0 4 172 174 177 175
		f 4 -441 463 465 -465
		mu 0 4 183 182 186 187
		f 4 -443 466 467 -464
		mu 0 4 275 274 276 277
		f 4 444 468 -470 -467
		mu 0 4 197 196 199 200
		f 4 -447 464 472 -472
		mu 0 4 188 183 187 189
		f 4 448 473 -475 -469
		mu 0 4 196 198 201 199
		f 4 449 471 -476 -474
		mu 0 4 403 402 404 405
		f 3 490 -41 -487
		mu 0 3 546 305 309
		f 4 -481 477 488 -479
		mu 0 4 302 297 542 308
		f 3 495 -43 -492
		mu 0 3 565 23 567
		f 4 -486 482 493 -484
		mu 0 4 291 286 300 301
		f 3 -489 486 -488
		mu 0 3 551 550 543
		f 4 -480 -490 -491 -478
		mu 0 4 544 548 547 306
		f 3 -494 491 -493
		mu 0 3 557 556 307
		f 4 -485 -495 -496 -483
		mu 0 4 25 564 566 24
		f 5 -498 476 110 -57 -497
		mu 0 5 434 435 436 431 430
		f 5 38 -499 496 -55 -36
		mu 0 5 41 45 46 47 43
		f 5 -59 -500 -501 481 41
		mu 0 5 18 19 20 21 14
		f 5 -111 107 -502 499 -110
		mu 0 5 431 436 441 442 437;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
	setAttr ".dfgi" 0;
	setAttr ".vcs" 2;
createNode lightLinker -s -n "lightLinker1";
	rename -uid "314FB172-4D58-C9C7-8D0A-A7A496E2D3C8";
	setAttr -s 9 ".lnk";
	setAttr -s 9 ".slnk";
createNode displayLayerManager -n "layerManager";
	rename -uid "2556A59D-42A8-E01B-EA58-859C103AB049";
createNode displayLayer -n "defaultLayer";
	rename -uid "6EA382F0-4574-CCF3-AFA0-158801951E81";
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "AF6CDF87-41FE-CC2A-58B3-8BB2E5DA5ACA";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "00695C5B-48A5-A6F2-D0FB-9E9B162E9F5B";
	setAttr ".g" yes;
createNode groupId -n "groupId5";
	rename -uid "8B4FDE43-42CC-0E06-B749-81BE9B7D68CF";
	setAttr ".ihi" 0;
createNode groupId -n "groupId10";
	rename -uid "2A79BBEA-4FC7-A448-22D1-299CE782A89E";
	setAttr ".ihi" 0;
createNode script -n "uiConfigurationScriptNode";
	rename -uid "67901D74-47BC-DBE3-B271-7EAFB89D7C2B";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"top\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"smoothShaded\" \n"
		+ "                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 1\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 0\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 1\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n"
		+ "                -rendererName \"vp2Renderer\" \n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n"
		+ "                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 705\n                -height 360\n                -sceneRenderFilter 0\n                $editorName;\n            modelEditor -e -viewSelected 0 $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 1\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 1\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n"
		+ "            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n"
		+ "            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 705\n            -height 360\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n"
		+ "\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"side\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 0\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 1\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n"
		+ "                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n                -rendererName \"vp2Renderer\" \n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n"
		+ "                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n"
		+ "                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 705\n                -height 359\n                -sceneRenderFilter 0\n                $editorName;\n            modelEditor -e -viewSelected 0 $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"wireframe\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 1\n"
		+ "            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n"
		+ "            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n"
		+ "            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 705\n            -height 359\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"front\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"smoothShaded\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 1\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n"
		+ "                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 0\n                -backfaceCulling 0\n                -xray 1\n                -jointXray 1\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n                -rendererName \"vp2Renderer\" \n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n"
		+ "                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n"
		+ "                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 705\n                -height 359\n                -sceneRenderFilter 0\n                $editorName;\n            modelEditor -e -viewSelected 0 $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"front\" \n"
		+ "            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 1\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 1\n            -jointXray 1\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n"
		+ "            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n"
		+ "            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 705\n            -height 359\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `modelPanel -unParent -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels `;\n"
		+ "\t\t\t$editorName = $panelName;\n            modelEditor -e \n                -camera \"persp\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"smoothShaded\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 0\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 1\n                -activeComponentsXray 0\n                -displayTextures 1\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n"
		+ "                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n                -rendererName \"vp2Renderer\" \n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 256 256 \n                -bumpResolution 512 512 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 1\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n"
		+ "                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n"
		+ "                -width 1416\n                -height 764\n                -sceneRenderFilter 0\n                $editorName;\n            modelEditor -e -viewSelected 0 $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 1\n            -activeComponentsXray 0\n            -displayTextures 1\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n"
		+ "            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n"
		+ "            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -greasePencils 1\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 1416\n            -height 764\n"
		+ "            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `outlinerPanel -unParent -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels `;\n\t\t\t$editorName = $panelName;\n            outlinerEditor -e \n                -showShapes 0\n                -showReferenceNodes 1\n                -showReferenceMembers 1\n                -showAttributes 0\n                -showConnected 0\n                -showAnimCurvesOnly 0\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 1\n                -showAssets 1\n                -showContainedOnly 1\n                -showPublishedAsConnected 0\n                -showContainerContents 1\n"
		+ "                -ignoreDagHierarchy 0\n                -expandConnections 0\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 0\n                -highlightActive 1\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"defaultSetFilter\" \n                -showSetMembers 1\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n"
		+ "                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 0\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showReferenceNodes 1\n            -showReferenceMembers 1\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n"
		+ "            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n"
		+ "            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"graphEditor\" -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n"
		+ "                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n"
		+ "                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -stackedCurves 0\n                -stackedCurvesMin -1\n"
		+ "                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n"
		+ "                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n"
		+ "                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 1\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -showResults \"off\" \n                -showBufferCurves \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -stackedCurves 0\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n"
		+ "                -stackedCurvesSpace 0.2\n                -displayNormalized 0\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -classicMode 1\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"dopeSheetPanel\" -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n"
		+ "                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n"
		+ "                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n"
		+ "                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n"
		+ "                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n"
		+ "                -ignoreOutlinerColor 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayKeys 1\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"clipEditorPanel\" -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels `;\n"
		+ "\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 0 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n"
		+ "\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"sequenceEditorPanel\" -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 1 \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n"
		+ "                -displayKeys 0\n                -displayTangents 0\n                -displayActiveKeys 0\n                -displayActiveKeyTangents 0\n                -displayInfinities 0\n                -autoFit 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -manageSequencer 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"hyperGraphPanel\" -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n"
		+ "                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n"
		+ "                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"visorPanel\" -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"createNodePanel\" -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"polyTexturePlacementPanel\" -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"renderWindowPanel\" -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n"
		+ "\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"blendShapePanel\" (localizedPanelLabel(\"Blend Shape\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\tblendShapePanel -unParent -l (localizedPanelLabel(\"Blend Shape\")) -mbv $menusOkayInPanels ;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tblendShapePanel -edit -l (localizedPanelLabel(\"Blend Shape\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"dynRelEdPanel\" -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"relationshipPanel\" -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"referenceEditorPanel\" -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"componentEditorPanel\" (localizedPanelLabel(\"Component Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"componentEditorPanel\" -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Component Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"dynPaintScriptedPanelType\" -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"scriptEditorPanel\" -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"profilerPanel\" -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"hyperShadePanel\" -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels `;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"nodeEditorPanel\" -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n"
		+ "                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -activeTab -1\n                -editorMode \"default\" \n                $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n"
		+ "                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -activeTab -1\n                -editorMode \"default\" \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"Stereo\" (localizedPanelLabel(\"Stereo\")) `;\n"
		+ "\tif (\"\" == $panelName) {\n\t\tif ($useSceneConfig) {\n\t\t\t$panelName = `scriptedPanel -unParent  -type \"Stereo\" -l (localizedPanelLabel(\"Stereo\")) -mbv $menusOkayInPanels `;\nstring $editorName = ($panelName+\"Editor\");\n            stereoCameraView -e \n                -camera \"persp\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n"
		+ "                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 4 4 \n                -bumpResolution 4 4 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 0\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n"
		+ "                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n"
		+ "                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 0\n                -height 0\n                -sceneRenderFilter 0\n                -displayMode \"centerEye\" \n                -viewColor 0 0 0 1 \n                -useCustomBackground 1\n                $editorName;\n            stereoCameraView -e -viewSelected 0 $editorName;\n\t\t}\n\t} else {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Stereo\")) -mbv $menusOkayInPanels  $panelName;\nstring $editorName = ($panelName+\"Editor\");\n            stereoCameraView -e \n                -camera \"persp\" \n                -useInteractiveMode 0\n                -displayLights \"default\" \n                -displayAppearance \"wireframe\" \n                -activeOnly 0\n                -ignorePanZoom 0\n                -wireframeOnShaded 0\n                -headsUpDisplay 1\n                -holdOuts 1\n                -selectionHiliteDisplay 1\n                -useDefaultMaterial 0\n"
		+ "                -bufferMode \"double\" \n                -twoSidedLighting 1\n                -backfaceCulling 0\n                -xray 0\n                -jointXray 0\n                -activeComponentsXray 0\n                -displayTextures 0\n                -smoothWireframe 0\n                -lineWidth 1\n                -textureAnisotropic 0\n                -textureHilight 1\n                -textureSampling 2\n                -textureDisplay \"modulate\" \n                -textureMaxSize 16384\n                -fogging 0\n                -fogSource \"fragment\" \n                -fogMode \"linear\" \n                -fogStart 0\n                -fogEnd 100\n                -fogDensity 0.1\n                -fogColor 0.5 0.5 0.5 1 \n                -depthOfFieldPreview 1\n                -maxConstantTransparency 1\n                -objectFilterShowInHUD 1\n                -isFiltered 0\n                -colorResolution 4 4 \n                -bumpResolution 4 4 \n                -textureCompression 0\n                -transparencyAlgorithm \"frontAndBackCull\" \n"
		+ "                -transpInShadows 0\n                -cullingOverride \"none\" \n                -lowQualityLighting 0\n                -maximumNumHardwareLights 0\n                -occlusionCulling 0\n                -shadingModel 0\n                -useBaseRenderer 0\n                -useReducedRenderer 0\n                -smallObjectCulling 0\n                -smallObjectThreshold -1 \n                -interactiveDisableShadows 0\n                -interactiveBackFaceCull 0\n                -sortTransparent 1\n                -nurbsCurves 1\n                -nurbsSurfaces 1\n                -polymeshes 1\n                -subdivSurfaces 1\n                -planes 1\n                -lights 1\n                -cameras 1\n                -controlVertices 1\n                -hulls 1\n                -grid 1\n                -imagePlane 1\n                -joints 1\n                -ikHandles 1\n                -deformers 1\n                -dynamics 1\n                -particleInstancers 1\n                -fluids 1\n                -hairSystems 1\n"
		+ "                -follicles 1\n                -nCloths 1\n                -nParticles 1\n                -nRigids 1\n                -dynamicConstraints 1\n                -locators 1\n                -manipulators 1\n                -pluginShapes 1\n                -dimensions 1\n                -handles 1\n                -pivots 1\n                -textures 1\n                -strokes 1\n                -motionTrails 1\n                -clipGhosts 1\n                -greasePencils 1\n                -shadows 0\n                -captureSequenceNumber -1\n                -width 0\n                -height 0\n                -sceneRenderFilter 0\n                -displayMode \"centerEye\" \n                -viewColor 0 0 0 1 \n                -useCustomBackground 1\n                $editorName;\n            stereoCameraView -e -viewSelected 0 $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n"
		+ "\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-defaultImage \"\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 1\\n    -activeComponentsXray 0\\n    -displayTextures 1\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1416\\n    -height 764\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 1\\n    -activeComponentsXray 0\\n    -displayTextures 1\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -greasePencils 1\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 1416\\n    -height 764\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        setFocus `paneLayout -q -p1 $gMainPane`;\n        sceneUIReplacement -deleteRemaining;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "48732AAF-4ACE-16E2-F2FF-FEA015D10255";
	setAttr ".b" -type "string" "playbackOptions -min 1 -max 120 -ast 1 -aet 200 ";
	setAttr ".st" 6;
createNode tweak -n "tweak1";
	rename -uid "3E500979-4809-2217-2582-929508742F40";
createNode objectSet -n "tweakSet1";
	rename -uid "C1941D5F-4C94-7228-1D17-E5A0E10AD11E";
	setAttr ".ihi" 0;
	setAttr ".vo" yes;
createNode groupId -n "groupId12";
	rename -uid "B7602658-4A13-657B-5921-6EB645DD336F";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts2";
	rename -uid "CB9F4228-4116-D675-BAEA-6B8EBAD042C1";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "vtx[*]";
createNode skinCluster -n "skinCluster1";
	rename -uid "CF650E7F-4E60-ADAB-D01A-569EDB8D43AF";
	setAttr -s 2 ".bw";
	setAttr ".bw[31]" 1;
	setAttr ".bw[116]" 0.48235294222831726;
	setAttr -s 254 ".wl";
	setAttr -s 6 ".wl[0].w";
	setAttr ".wl[0].w[0]" 0.47276925088170285;
	setAttr ".wl[0].w[13]" 0.0075230237467683115;
	setAttr ".wl[0].w[19]" 0.025773330773083331;
	setAttr ".wl[0].w[25]" 0.47276925088170285;
	setAttr ".wl[0].w[26]" 0.021153974117417668;
	setAttr ".wl[0].w[32]" 1.1169599325075817e-005;
	setAttr -s 5 ".wl[1].w";
	setAttr ".wl[1].w[0]" 0.41585279127692643;
	setAttr ".wl[1].w[1]" 0.026048181852808761;
	setAttr ".wl[1].w[7]" 0.0081366058348873223;
	setAttr ".wl[1].w[32]" 0.41592213434110786;
	setAttr ".wl[1].w[33]" 0.13404027479080288;
	setAttr -s 6 ".wl[2].w";
	setAttr ".wl[2].w[0]" 0.1314111692417371;
	setAttr ".wl[2].w[13]" 0.011863663609421879;
	setAttr ".wl[2].w[19]" 0.037895662195769585;
	setAttr ".wl[2].w[25]" 0.63455068292662586;
	setAttr ".wl[2].w[26]" 0.18425803598208201;
	setAttr ".wl[2].w[32]" 2.0761175140465336e-005;
	setAttr -s 6 ".wl[3].w";
	setAttr ".wl[3].w[0]" 0.14161068112394931;
	setAttr ".wl[3].w[1]" 0.027412829474536361;
	setAttr ".wl[3].w[7]" 0.010961708221058726;
	setAttr ".wl[3].w[25]" 2.8867146404314197e-006;
	setAttr ".wl[3].w[32]" 0.32485450637091645;
	setAttr ".wl[3].w[33]" 0.49515741833377852;
	setAttr -s 7 ".wl[4].w";
	setAttr ".wl[4].w[0]" 0.18455315327993405;
	setAttr ".wl[4].w[7]" 9.5591389623932801e-006;
	setAttr ".wl[4].w[13]" 0.3817919515347481;
	setAttr ".wl[4].w[14]" 3.5604329197317545e-007;
	setAttr ".wl[4].w[19]" 0.13500416940053872;
	setAttr ".wl[4].w[25]" 0.16539710761555007;
	setAttr ".wl[4].w[26]" 0.13324370298697474;
	setAttr -s 6 ".wl[5].w";
	setAttr ".wl[5].w[0]" 0.1983240793692348;
	setAttr ".wl[5].w[1]" 0.14173747098883593;
	setAttr ".wl[5].w[7]" 0.52326440081069425;
	setAttr ".wl[5].w[13]" 0.027445190777679172;
	setAttr ".wl[5].w[32]" 0.10921673377861683;
	setAttr ".wl[5].w[33]" 1.2124274939006679e-005;
	setAttr -s 5 ".wl[6].w";
	setAttr ".wl[6].w[0]" 0.15058363154137638;
	setAttr ".wl[6].w[13]" 0.1513534893198723;
	setAttr ".wl[6].w[14]" 0.056920869965243197;
	setAttr ".wl[6].w[19]" 0.51715892553329468;
	setAttr ".wl[6].w[20]" 0.12398308364021343;
	setAttr -s 5 ".wl[7].w";
	setAttr ".wl[7].w[0]" 0.30563136055999318;
	setAttr ".wl[7].w[1]" 0.093222712052536238;
	setAttr ".wl[7].w[7]" 0.41151371598243713;
	setAttr ".wl[7].w[8]" 0.18031769660388575;
	setAttr ".wl[7].w[32]" 0.0093145148011475991;
	setAttr -s 7 ".wl[8].w";
	setAttr ".wl[8].w[0]" 0.2834245866911384;
	setAttr ".wl[8].w[1]" 2.4318621123890863e-005;
	setAttr ".wl[8].w[7]" 0.029009704121038406;
	setAttr ".wl[8].w[13]" 0.48474977553430998;
	setAttr ".wl[8].w[19]" 0.10519458411774829;
	setAttr ".wl[8].w[25]" 0.097569261165891916;
	setAttr ".wl[8].w[32]" 2.7769737835035289e-005;
	setAttr -s 5 ".wl[9].w";
	setAttr ".wl[9].w[0]" 0.45059036475457914;
	setAttr ".wl[9].w[7]" 0.017182700457109273;
	setAttr ".wl[9].w[13]" 0.40440506914295721;
	setAttr ".wl[9].w[14]" 0.074992761015892029;
	setAttr ".wl[9].w[19]" 0.052829104629462345;
	setAttr -s 6 ".wl[10].w";
	setAttr ".wl[10].w[0]" 0.46731583128000237;
	setAttr ".wl[10].w[1]" 1.1397705974121564e-005;
	setAttr ".wl[10].w[19]" 0.026432749206794601;
	setAttr ".wl[10].w[25]" 0.46728585878886875;
	setAttr ".wl[10].w[26]" 0.017655813681677429;
	setAttr ".wl[10].w[32]" 0.021298349336682624;
	setAttr -s 6 ".wl[11].w";
	setAttr ".wl[11].w[0]" 0.24543749917288377;
	setAttr ".wl[11].w[19]" 0.073857473880116709;
	setAttr ".wl[11].w[25]" 0.43075683820717714;
	setAttr ".wl[11].w[26]" 0.19307806385819704;
	setAttr ".wl[11].w[32]" 0.056838798458003971;
	setAttr ".wl[11].w[33]" 3.1326423621374902e-005;
	setAttr -s 6 ".wl[12].w";
	setAttr ".wl[12].w[0]" 0.26078161256924043;
	setAttr ".wl[12].w[1]" 0.068303869748542287;
	setAttr ".wl[12].w[7]" 1.2248087627533365e-005;
	setAttr ".wl[12].w[25]" 0.053023256019122909;
	setAttr ".wl[12].w[32]" 0.35390158756712364;
	setAttr ".wl[12].w[33]" 0.26397744265573425;
	setAttr -s 5 ".wl[13].w";
	setAttr ".wl[13].w[0]" 0.24707787012836666;
	setAttr ".wl[13].w[1]" 0.11106149206585957;
	setAttr ".wl[13].w[7]" 0.39340201975026073;
	setAttr ".wl[13].w[13]" 0.15765894214523657;
	setAttr ".wl[13].w[32]" 0.090799687911968491;
	setAttr -s 5 ".wl[14].w";
	setAttr ".wl[14].w[0]" 0.47630300242747703;
	setAttr ".wl[14].w[1]" 0.045034563674682546;
	setAttr ".wl[14].w[7]" 0.44472822902312636;
	setAttr ".wl[14].w[8]" 0.022219494120987202;
	setAttr ".wl[14].w[32]" 0.01171472280271269;
	setAttr -s 6 ".wl[15].w";
	setAttr ".wl[15].w[0]" 0.45175997229885356;
	setAttr ".wl[15].w[1]" 0.028872956147273112;
	setAttr ".wl[15].w[7]" 4.659901075085396e-006;
	setAttr ".wl[15].w[25]" 0.023223436803774988;
	setAttr ".wl[15].w[32]" 0.45175997229885367;
	setAttr ".wl[15].w[33]" 0.044379002550169577;
	setAttr -s 6 ".wl[16].w";
	setAttr ".wl[16].w[0]" 0.25247859125549876;
	setAttr ".wl[16].w[1]" 0.036209464610011795;
	setAttr ".wl[16].w[7]" 1.7376560898823502e-005;
	setAttr ".wl[16].w[25]" 0.018149912493808113;
	setAttr ".wl[16].w[32]" 0.30831637349011221;
	setAttr ".wl[16].w[33]" 0.38482828159694632;
	setAttr -s 5 ".wl[17].w";
	setAttr ".wl[17].w[0]" 0.34186442429350133;
	setAttr ".wl[17].w[1]" 0.049261268101468088;
	setAttr ".wl[17].w[25]" 0.052091179180059032;
	setAttr ".wl[17].w[32]" 0.37426089741543339;
	setAttr ".wl[17].w[33]" 0.18252223100953824;
	setAttr -s 6 ".wl[18].w";
	setAttr ".wl[18].w[0]" 0.29548215748897633;
	setAttr ".wl[18].w[19]" 0.048493557282294361;
	setAttr ".wl[18].w[25]" 0.50428476824919244;
	setAttr ".wl[18].w[26]" 0.10115773325351206;
	setAttr ".wl[18].w[32]" 0.050558593268206824;
	setAttr ".wl[18].w[33]" 2.3190457817990807e-005;
	setAttr -s 5 ".wl[19].w";
	setAttr ".wl[19].w[0]" 0.21752703788962269;
	setAttr ".wl[19].w[19]" 0.036906213419424017;
	setAttr ".wl[19].w[25]" 0.61640148257888794;
	setAttr ".wl[19].w[26]" 0.11258344132356032;
	setAttr ".wl[19].w[32]" 0.016581804997900306;
	setAttr -s 6 ".wl[20].w";
	setAttr ".wl[20].w[0]" 0.078105067460529976;
	setAttr ".wl[20].w[7]" 1.9824303021904112e-006;
	setAttr ".wl[20].w[13]" 0.69846386899021928;
	setAttr ".wl[20].w[14]" 0.025196201147428984;
	setAttr ".wl[20].w[19]" 0.1629462025574277;
	setAttr ".wl[20].w[25]" 0.035286677406815917;
	setAttr -s 8 ".wl[21].w";
	setAttr ".wl[21].w[0]" 0.0460904476653793;
	setAttr ".wl[21].w[1]" 1.1931575691211734e-005;
	setAttr ".wl[21].w[7]" 7.6365977841130135e-005;
	setAttr ".wl[21].w[8]" 1.9990479554718689e-005;
	setAttr ".wl[21].w[13]" 0.89112926675663717;
	setAttr ".wl[21].w[14]" 0.03012937915847811;
	setAttr ".wl[21].w[19]" 0.028622767170282705;
	setAttr ".wl[21].w[25]" 0.0039198644001708915;
	setAttr -s 5 ".wl[22].w";
	setAttr ".wl[22].w[0]" 0.082198028718120958;
	setAttr ".wl[22].w[1]" 0.14917594320237276;
	setAttr ".wl[22].w[7]" 0.44648484854808168;
	setAttr ".wl[22].w[13]" 0.1876909068834898;
	setAttr ".wl[22].w[32]" 0.13445027343373819;
	setAttr -s 6 ".wl[23].w";
	setAttr ".wl[23].w[0]" 0.023106764961793903;
	setAttr ".wl[23].w[1]" 0.48233587128576716;
	setAttr ".wl[23].w[7]" 0.22679922096844185;
	setAttr ".wl[23].w[13]" 0.023807482531846644;
	setAttr ".wl[23].w[32]" 0.24394729628393341;
	setAttr ".wl[23].w[33]" 3.4016476729776025e-006;
	setAttr -s 6 ".wl[24].w";
	setAttr ".wl[24].w[0]" 0.34624061222090835;
	setAttr ".wl[24].w[1]" 0.014165589267170601;
	setAttr ".wl[24].w[7]" 2.6410433060076143e-007;
	setAttr ".wl[24].w[25]" 0.0062352659639801754;
	setAttr ".wl[24].w[32]" 0.34975094405076823;
	setAttr ".wl[24].w[33]" 0.28360732439284209;
	setAttr -s 5 ".wl[25].w";
	setAttr ".wl[25].w[0]" 0.422875576552039;
	setAttr ".wl[25].w[1]" 0.022814601954831398;
	setAttr ".wl[25].w[25]" 0.025256747525296927;
	setAttr ".wl[25].w[32]" 0.41381402813176521;
	setAttr ".wl[25].w[33]" 0.11523904583606753;
	setAttr -s 6 ".wl[26].w";
	setAttr ".wl[26].w[0]" 0.46156293199161119;
	setAttr ".wl[26].w[1]" 1.2404676574036211e-005;
	setAttr ".wl[26].w[19]" 0.027422014393658697;
	setAttr ".wl[26].w[25]" 0.44791479375845267;
	setAttr ".wl[26].w[26]" 0.033110100058534403;
	setAttr ".wl[26].w[32]" 0.029977755121169035;
	setAttr -s 5 ".wl[27].w";
	setAttr ".wl[27].w[0]" 0.20666933341240135;
	setAttr ".wl[27].w[19]" 0.0095260055309965043;
	setAttr ".wl[27].w[25]" 0.76322181325714866;
	setAttr ".wl[27].w[26]" 0.016875628338096971;
	setAttr ".wl[27].w[32]" 0.0037072185882416533;
	setAttr -s 5 ".wl[28].w";
	setAttr ".wl[28].w[0]" 0.064400829943935881;
	setAttr ".wl[28].w[13]" 0.52391784684775677;
	setAttr ".wl[28].w[14]" 0.039383655509105268;
	setAttr ".wl[28].w[19]" 0.30955256594930503;
	setAttr ".wl[28].w[25]" 0.062745101749897003;
	setAttr -s 6 ".wl[29].w";
	setAttr ".wl[29].w[0]" 0.037384817781271763;
	setAttr ".wl[29].w[7]" 5.8779758771489874e-005;
	setAttr ".wl[29].w[13]" 0.8533989782150484;
	setAttr ".wl[29].w[14]" 0.056441673287968591;
	setAttr ".wl[29].w[19]" 0.040955051937754186;
	setAttr ".wl[29].w[25]" 0.011760690800991423;
	setAttr -s 5 ".wl[30].w";
	setAttr ".wl[30].w[0]" 0.04047809389640078;
	setAttr ".wl[30].w[1]" 0.15294118225574493;
	setAttr ".wl[30].w[7]" 0.54746686962939284;
	setAttr ".wl[30].w[13]" 0.10986736894224639;
	setAttr ".wl[30].w[32]" 0.14924648527621509;
	setAttr -s 5 ".wl[31].w";
	setAttr ".wl[31].w[0]" 0.010871225131516902;
	setAttr ".wl[31].w[1]" 0.52549022436141968;
	setAttr ".wl[31].w[2]" 0.011339884592205947;
	setAttr ".wl[31].w[7]" 0.18745470173069018;
	setAttr ".wl[31].w[32]" 0.26484396418416734;
	setAttr -s 5 ".wl[32].w";
	setAttr ".wl[32].w[0]" 0.066852415140512947;
	setAttr ".wl[32].w[1]" 0.043945485971793694;
	setAttr ".wl[32].w[7]" 0.057595338507488034;
	setAttr ".wl[32].w[32]" 0.74160736213010525;
	setAttr ".wl[32].w[33]" 0.089999391118183669;
	setAttr -s 6 ".wl[33].w";
	setAttr ".wl[33].w[0]" 0.24418933927856337;
	setAttr ".wl[33].w[1]" 0.1238773085279017;
	setAttr ".wl[33].w[7]" 0.16205213562581763;
	setAttr ".wl[33].w[13]" 1.3187761023980291e-007;
	setAttr ".wl[33].w[32]" 0.24760032376760555;
	setAttr ".wl[33].w[33]" 0.2222807370591795;
	setAttr -s 7 ".wl[34].w";
	setAttr ".wl[34].w[0]" 0.20176698261694007;
	setAttr ".wl[34].w[7]" 3.7450638793202134e-005;
	setAttr ".wl[34].w[13]" 0.15342749957683477;
	setAttr ".wl[34].w[19]" 0.11244100212733099;
	setAttr ".wl[34].w[25]" 0.3470382425317915;
	setAttr ".wl[34].w[26]" 0.18523031713386826;
	setAttr ".wl[34].w[32]" 5.8505374441247461e-005;
	setAttr -s 5 ".wl[35].w";
	setAttr ".wl[35].w[0]" 0.04591949515057777;
	setAttr ".wl[35].w[13]" 0.054960935172004351;
	setAttr ".wl[35].w[19]" 0.18526982526568492;
	setAttr ".wl[35].w[25]" 0.56592095724633307;
	setAttr ".wl[35].w[26]" 0.14792878716539989;
	setAttr -s 5 ".wl[36].w";
	setAttr ".wl[36].w[0]" 0.037155382574101663;
	setAttr ".wl[36].w[13]" 0.010158652347611498;
	setAttr ".wl[36].w[19]" 0.120815846093257;
	setAttr ".wl[36].w[25]" 0.74288122869837137;
	setAttr ".wl[36].w[26]" 0.088988908301929473;
	setAttr -s 5 ".wl[37].w";
	setAttr ".wl[37].w[0]" 0.0061279253252922838;
	setAttr ".wl[37].w[13]" 0.00010936181026239394;
	setAttr ".wl[37].w[19]" 0.031834819485143467;
	setAttr ".wl[37].w[25]" 0.95731198787689209;
	setAttr ".wl[37].w[26]" 0.004615905502409764;
	setAttr -s 5 ".wl[38].w";
	setAttr ".wl[38].w[0]" 0.16745282317590029;
	setAttr ".wl[38].w[13]" 0.0043166375857500959;
	setAttr ".wl[38].w[19]" 0.66266733407974243;
	setAttr ".wl[38].w[25]" 0.16009991079868011;
	setAttr ".wl[38].w[26]" 0.0054632943599270956;
	setAttr -s 5 ".wl[39].w";
	setAttr ".wl[39].w[0]" 0.66181649028475886;
	setAttr ".wl[39].w[13]" 0.015635927550803088;
	setAttr ".wl[39].w[19]" 0.0287742951086771;
	setAttr ".wl[39].w[25]" 0.2872205639856043;
	setAttr ".wl[39].w[32]" 0.0065527230701565983;
	setAttr -s 5 ".wl[40].w";
	setAttr ".wl[40].w[0]" 0.62598069738556195;
	setAttr ".wl[40].w[1]" 0.035228734993354521;
	setAttr ".wl[40].w[7]" 0.01835003140778874;
	setAttr ".wl[40].w[32]" 0.29705752787717871;
	setAttr ".wl[40].w[33]" 0.023383020385101819;
	setAttr -s 5 ".wl[41].w";
	setAttr ".wl[41].w[0]" 0.46642322476381454;
	setAttr ".wl[41].w[1]" 0.06512698472156711;
	setAttr ".wl[41].w[7]" 0.01502660434188996;
	setAttr ".wl[41].w[32]" 0.44397968270084742;
	setAttr ".wl[41].w[33]" 0.0094435187950478276;
	setAttr -s 6 ".wl[42].w";
	setAttr ".wl[42].w[0]" 0.060288946415377034;
	setAttr ".wl[42].w[1]" 0.3291948957397105;
	setAttr ".wl[42].w[7]" 0.092284388440344381;
	setAttr ".wl[42].w[32]" 0.49498240343747135;
	setAttr ".wl[42].w[33]" 0.023244396136588293;
	setAttr ".wl[42].w[34]" 4.9698305084056716e-006;
	setAttr -s 6 ".wl[43].w";
	setAttr ".wl[43].w[0]" 0.034353553122870285;
	setAttr ".wl[43].w[1]" 0.41694128163021865;
	setAttr ".wl[43].w[7]" 0.051476141086717268;
	setAttr ".wl[43].w[32]" 0.43209071694009804;
	setAttr ".wl[43].w[33]" 0.065136531075923515;
	setAttr ".wl[43].w[34]" 1.7761441722602216e-006;
	setAttr -s 5 ".wl[44].w";
	setAttr ".wl[44].w[0]" 0.091429410855761395;
	setAttr ".wl[44].w[1]" 0.02837375565749533;
	setAttr ".wl[44].w[7]" 0.034380308732770586;
	setAttr ".wl[44].w[32]" 0.44593463395667099;
	setAttr ".wl[44].w[33]" 0.39988188087289556;
	setAttr -s 5 ".wl[45].w";
	setAttr ".wl[45].w[0]" 0.2536256842942527;
	setAttr ".wl[45].w[1]" 0.098433298097981264;
	setAttr ".wl[45].w[7]" 0.092276728651526585;
	setAttr ".wl[45].w[32]" 0.29757038997424334;
	setAttr ".wl[45].w[33]" 0.25809387649928717;
	setAttr -s 7 ".wl[46].w";
	setAttr ".wl[46].w[0]" 0.21459614708077168;
	setAttr ".wl[46].w[13]" 0.065729441231929822;
	setAttr ".wl[46].w[19]" 0.094260449488194162;
	setAttr ".wl[46].w[25]" 0.40543841040700102;
	setAttr ".wl[46].w[26]" 0.21987025647133063;
	setAttr ".wl[46].w[32]" 7.075258847927314e-005;
	setAttr ".wl[46].w[33]" 3.4542732293398259e-005;
	setAttr -s 6 ".wl[47].w";
	setAttr ".wl[47].w[0]" 0.064968292193770247;
	setAttr ".wl[47].w[13]" 0.010566664477011245;
	setAttr ".wl[47].w[19]" 0.05334818524323727;
	setAttr ".wl[47].w[25]" 0.71563681810237723;
	setAttr ".wl[47].w[26]" 0.15547596561323013;
	setAttr ".wl[47].w[32]" 4.0743703738882905e-006;
	setAttr -s 5 ".wl[48].w";
	setAttr ".wl[48].w[0]" 0.058931960556170983;
	setAttr ".wl[48].w[13]" 0.007167216797159549;
	setAttr ".wl[48].w[19]" 0.042497416532728587;
	setAttr ".wl[48].w[25]" 0.77041986921070749;
	setAttr ".wl[48].w[26]" 0.12098353690323337;
	setAttr -s 6 ".wl[49].w";
	setAttr ".wl[49].w[0]" 0.022511151305692985;
	setAttr ".wl[49].w[13]" 0.00012874848505284423;
	setAttr ".wl[49].w[19]" 0.0065977073462804969;
	setAttr ".wl[49].w[25]" 0.95443893435073968;
	setAttr ".wl[49].w[26]" 0.016321714510177599;
	setAttr ".wl[49].w[32]" 1.740932511733017e-006;
	setAttr -s 6 ".wl[50].w";
	setAttr ".wl[50].w[0]" 0.48556106560229434;
	setAttr ".wl[50].w[13]" 0.0042921738767394517;
	setAttr ".wl[50].w[19]" 0.017270824832951094;
	setAttr ".wl[50].w[25]" 0.48553775609495076;
	setAttr ".wl[50].w[26]" 0.0073331607134731608;
	setAttr ".wl[50].w[32]" 5.0188795911999486e-006;
	setAttr -s 6 ".wl[51].w";
	setAttr ".wl[51].w[0]" 0.50340660911808277;
	setAttr ".wl[51].w[1]" 9.601958812119661e-006;
	setAttr ".wl[51].w[13]" 0.0085104459759645784;
	setAttr ".wl[51].w[19]" 0.019420273934813305;
	setAttr ".wl[51].w[25]" 0.4590525808290648;
	setAttr ".wl[51].w[32]" 0.0096004819841465985;
	setAttr -s 6 ".wl[52].w";
	setAttr ".wl[52].w[0]" 0.49095436375055423;
	setAttr ".wl[52].w[1]" 0.022680818230917194;
	setAttr ".wl[52].w[7]" 2.9316408430626724e-006;
	setAttr ".wl[52].w[25]" 0.010723588076536072;
	setAttr ".wl[52].w[32]" 0.45219225521857542;
	setAttr ".wl[52].w[33]" 0.023446055131559892;
	setAttr -s 6 ".wl[53].w";
	setAttr ".wl[53].w[0]" 0.42795170771998736;
	setAttr ".wl[53].w[1]" 0.019253021271178623;
	setAttr ".wl[53].w[7]" 0.0051202615025111552;
	setAttr ".wl[53].w[32]" 0.42797357965723232;
	setAttr ".wl[53].w[33]" 0.11969755149120279;
	setAttr ".wl[53].w[34]" 3.8783506117905965e-006;
	setAttr -s 6 ".wl[54].w";
	setAttr ".wl[54].w[0]" 0.129919070228948;
	setAttr ".wl[54].w[1]" 0.0023541503531977108;
	setAttr ".wl[54].w[7]" 0.00056380181020471523;
	setAttr ".wl[54].w[32]" 0.46964128245667697;
	setAttr ".wl[54].w[33]" 0.39751175561362312;
	setAttr ".wl[54].w[34]" 9.9433062955471357e-006;
	setAttr -s 6 ".wl[55].w";
	setAttr ".wl[55].w[0]" 0.090604987306072568;
	setAttr ".wl[55].w[1]" 0.022780482844937496;
	setAttr ".wl[55].w[7]" 0.043795606339487148;
	setAttr ".wl[55].w[32]" 0.43228606407536291;
	setAttr ".wl[55].w[33]" 0.41053248381774282;
	setAttr ".wl[55].w[34]" 3.4609783705619179e-007;
	setAttr -s 5 ".wl[56].w";
	setAttr ".wl[56].w[0]" 0.244265749165124;
	setAttr ".wl[56].w[1]" 0.057182121686795769;
	setAttr ".wl[56].w[7]" 0.2528436811992118;
	setAttr ".wl[56].w[13]" 0.38957026854651366;
	setAttr ".wl[56].w[32]" 0.056138185106705527;
	setAttr -s 8 ".wl[57].w";
	setAttr ".wl[57].w[0]" 0.0934514793730222;
	setAttr ".wl[57].w[1]" 0.027505513141932225;
	setAttr ".wl[57].w[7]" 0.17581674551100274;
	setAttr ".wl[57].w[8]" 0.045971472379230327;
	setAttr ".wl[57].w[13]" 0.65719450124826939;
	setAttr ".wl[57].w[14]" 7.2350082105784661e-010;
	setAttr ".wl[57].w[19]" 4.3914143160171623e-011;
	setAttr ".wl[57].w[32]" 6.0287579128164661e-005;
	setAttr -s 5 ".wl[58].w";
	setAttr ".wl[58].w[0]" 0.078372274384361687;
	setAttr ".wl[58].w[7]" 0.1886259890160453;
	setAttr ".wl[58].w[13]" 0.64421999454498291;
	setAttr ".wl[58].w[14]" 0.083701343166938696;
	setAttr ".wl[58].w[19]" 0.005080398887671359;
	setAttr -s 8 ".wl[59].w";
	setAttr ".wl[59].w[0]" 0.55606206847109096;
	setAttr ".wl[59].w[1]" 1.3519652805065933e-005;
	setAttr ".wl[59].w[7]" 0.092808761729903461;
	setAttr ".wl[59].w[8]" 5.104479382063081e-006;
	setAttr ".wl[59].w[13]" 0.22965446172287685;
	setAttr ".wl[59].w[19]" 0.10246626210963747;
	setAttr ".wl[59].w[32]" 0.018987743697021078;
	setAttr ".wl[59].w[33]" 2.0844964699693182e-006;
	setAttr -s 7 ".wl[60].w";
	setAttr ".wl[60].w[0]" 0.7405825020292478;
	setAttr ".wl[60].w[1]" 1.1260430623855907e-005;
	setAttr ".wl[60].w[7]" 0.028971369313582639;
	setAttr ".wl[60].w[13]" 0.026544553985108521;
	setAttr ".wl[60].w[25]" 0.098233593623813453;
	setAttr ".wl[60].w[32]" 0.10564925399785322;
	setAttr ".wl[60].w[33]" 7.480269467131039e-006;
	setAttr -s 6 ".wl[61].w";
	setAttr ".wl[61].w[0]" 0.50178561480492534;
	setAttr ".wl[61].w[1]" 0.030989524499257456;
	setAttr ".wl[61].w[19]" 0.028491818967930568;
	setAttr ".wl[61].w[25]" 0.21400135349470467;
	setAttr ".wl[61].w[32]" 0.22472420828299489;
	setAttr ".wl[61].w[33]" 7.4799501870170815e-006;
	setAttr -s 6 ".wl[62].w";
	setAttr ".wl[62].w[0]" 0.37179396149514488;
	setAttr ".wl[62].w[1]" 0.036785772771409708;
	setAttr ".wl[62].w[19]" 0.034896419869570379;
	setAttr ".wl[62].w[25]" 0.27494611027045751;
	setAttr ".wl[62].w[32]" 0.28156356053938258;
	setAttr ".wl[62].w[33]" 1.4175054035003853e-005;
	setAttr -s 7 ".wl[63].w";
	setAttr ".wl[63].w[0]" 0.41030116821207457;
	setAttr ".wl[63].w[1]" 0.032713540710158848;
	setAttr ".wl[63].w[19]" 0.031926957841833914;
	setAttr ".wl[63].w[25]" 0.2473219423936221;
	setAttr ".wl[63].w[26]" 1.1596181620288388e-009;
	setAttr ".wl[63].w[32]" 0.27769048603626839;
	setAttr ".wl[63].w[33]" 4.590364642392279e-005;
	setAttr -s 6 ".wl[64].w";
	setAttr ".wl[64].w[0]" 0.32754258343807091;
	setAttr ".wl[64].w[1]" 1.8855841345215049e-005;
	setAttr ".wl[64].w[25]" 0.28943596085542117;
	setAttr ".wl[64].w[26]" 0.058658215915294153;
	setAttr ".wl[64].w[32]" 0.26080813156427729;
	setAttr ".wl[64].w[33]" 0.063536252385591324;
	setAttr -s 6 ".wl[65].w";
	setAttr ".wl[65].w[0]" 0.30734660739297781;
	setAttr ".wl[65].w[1]" 2.1848219407267723e-005;
	setAttr ".wl[65].w[25]" 0.24655002540764939;
	setAttr ".wl[65].w[26]" 0.094743966113620279;
	setAttr ".wl[65].w[32]" 0.25017542089425021;
	setAttr ".wl[65].w[33]" 0.10116213197209506;
	setAttr -s 7 ".wl[66].w";
	setAttr ".wl[66].w[0]" 0.33403331548053306;
	setAttr ".wl[66].w[1]" 3.148606820801371e-005;
	setAttr ".wl[66].w[7]" 2.9515358370410968e-005;
	setAttr ".wl[66].w[25]" 0.22156264997394892;
	setAttr ".wl[66].w[26]" 0.10441982121530408;
	setAttr ".wl[66].w[32]" 0.22838521250230354;
	setAttr ".wl[66].w[33]" 0.11153799940133199;
	setAttr -s 7 ".wl[67].w";
	setAttr ".wl[67].w[0]" 0.37708345756168599;
	setAttr ".wl[67].w[1]" 3.9625587264611331e-005;
	setAttr ".wl[67].w[7]" 0.12088995359360517;
	setAttr ".wl[67].w[13]" 0.13214262468528995;
	setAttr ".wl[67].w[25]" 0.18092087203454277;
	setAttr ".wl[67].w[32]" 0.18885236524314608;
	setAttr ".wl[67].w[33]" 7.1101294465414355e-005;
	setAttr -s 5 ".wl[68].w";
	setAttr ".wl[68].w[8]" 0.0014651731265763479;
	setAttr ".wl[68].w[13]" 0.36862745881080627;
	setAttr ".wl[68].w[14]" 0.37215395205493718;
	setAttr ".wl[68].w[19]" 0.039615534339006997;
	setAttr ".wl[68].w[20]" 0.21813788166867318;
	setAttr -s 5 ".wl[69].w";
	setAttr ".wl[69].w[8]" 0.05462514711422211;
	setAttr ".wl[69].w[13]" 0.00032425765658334476;
	setAttr ".wl[69].w[14]" 0.81516981360411589;
	setAttr ".wl[69].w[15]" 0.00046577617959825992;
	setAttr ".wl[69].w[20]" 0.12941500544548035;
	setAttr -s 5 ".wl[70].w";
	setAttr ".wl[70].w[0]" 0.009150589556697529;
	setAttr ".wl[70].w[13]" 0.11487336876903209;
	setAttr ".wl[70].w[14]" 0.85997146368026733;
	setAttr ".wl[70].w[19]" 0.0083132440854314631;
	setAttr ".wl[70].w[20]" 0.0076913339085715746;
	setAttr -s 5 ".wl[71].w";
	setAttr ".wl[71].w[0]" 0.0002252104213939976;
	setAttr ".wl[71].w[13]" 0.015479269437491894;
	setAttr ".wl[71].w[14]" 0.062301423406319431;
	setAttr ".wl[71].w[19]" 0.035421394758115156;
	setAttr ".wl[71].w[20]" 0.88657270197667959;
	setAttr -s 5 ".wl[72].w";
	setAttr ".wl[72].w[2]" 0.13619378209114075;
	setAttr ".wl[72].w[8]" 0.82892918275187089;
	setAttr ".wl[72].w[9]" 0.0023180180983452285;
	setAttr ".wl[72].w[13]" 0.030531247525125885;
	setAttr ".wl[72].w[14]" 0.0020277695335172504;
	setAttr -s 5 ".wl[73].w";
	setAttr ".wl[73].w[0]" 0.033421899537465355;
	setAttr ".wl[73].w[1]" 0.026406127577583496;
	setAttr ".wl[73].w[2]" 0.023287830679800964;
	setAttr ".wl[73].w[7]" 0.45844207110257512;
	setAttr ".wl[73].w[8]" 0.45844207110257512;
	setAttr -s 5 ".wl[74].w";
	setAttr ".wl[74].w[1]" 0.0039215688593685627;
	setAttr ".wl[74].w[2]" 0.4664221583595729;
	setAttr ".wl[74].w[7]" 0.16735066444652433;
	setAttr ".wl[74].w[8]" 0.36022595842912242;
	setAttr ".wl[74].w[32]" 0.0020796499054117497;
	setAttr -s 5 ".wl[75].w";
	setAttr ".wl[75].w[0]" 0.00091063558881892583;
	setAttr ".wl[75].w[1]" 0.0017331585386086087;
	setAttr ".wl[75].w[2]" 0.001559770308068291;
	setAttr ".wl[75].w[7]" 0.023226916790008545;
	setAttr ".wl[75].w[8]" 0.9725695187744956;
	setAttr -s 5 ".wl[76].w";
	setAttr ".wl[76].w[13]" 1.1643621032733078e-006;
	setAttr ".wl[76].w[14]" 0.11851347682424332;
	setAttr ".wl[76].w[15]" 0.81481058658376115;
	setAttr ".wl[76].w[20]" 0.066672265529632568;
	setAttr ".wl[76].w[21]" 2.5067002597100367e-006;
	setAttr -s 5 ".wl[77].w";
	setAttr ".wl[77].w[8]" 1.0795007467089733e-007;
	setAttr ".wl[77].w[9]" 1.1111379997888952e-007;
	setAttr ".wl[77].w[14]" 0.042814105749130249;
	setAttr ".wl[77].w[15]" 0.95718556061443305;
	setAttr ".wl[77].w[20]" 1.145725620725229e-007;
	setAttr -s 5 ".wl[78].w";
	setAttr ".wl[78].w[8]" 4.6529878504576747e-006;
	setAttr ".wl[78].w[13]" 5.069327426106711e-006;
	setAttr ".wl[78].w[14]" 0.037557877600193024;
	setAttr ".wl[78].w[15]" 0.96242757822115732;
	setAttr ".wl[78].w[20]" 4.8218633731684761e-006;
	setAttr -s 5 ".wl[79].w";
	setAttr ".wl[79].w[13]" 0.00020030400156843264;
	setAttr ".wl[79].w[14]" 0.14468143880367279;
	setAttr ".wl[79].w[15]" 0.85437247724903076;
	setAttr ".wl[79].w[20]" 0.00056426116223168884;
	setAttr ".wl[79].w[21]" 0.00018151878349627654;
	setAttr -s 5 ".wl[80].w";
	setAttr ".wl[80].w[2]" 2.989674675072335e-005;
	setAttr ".wl[80].w[8]" 0.052964001893997192;
	setAttr ".wl[80].w[9]" 0.9469528502399609;
	setAttr ".wl[80].w[14]" 2.6254027351545016e-005;
	setAttr ".wl[80].w[15]" 2.6997091939661084e-005;
	setAttr -s 5 ".wl[81].w";
	setAttr ".wl[81].w[2]" 0.0012119722419690734;
	setAttr ".wl[81].w[7]" 0.0012741754188031397;
	setAttr ".wl[81].w[8]" 0.63098303224068564;
	setAttr ".wl[81].w[9]" 0.36544756654691707;
	setAttr ".wl[81].w[14]" 0.001083253551624995;
	setAttr -s 5 ".wl[82].w";
	setAttr ".wl[82].w[2]" 0.061841052025556564;
	setAttr ".wl[82].w[3]" 2.9978429472977868e-005;
	setAttr ".wl[82].w[7]" 1.4443048764855527e-005;
	setAttr ".wl[82].w[8]" 0.15387731270049063;
	setAttr ".wl[82].w[9]" 0.78423721379571498;
	setAttr -s 2 ".wl[83].w[8:9]"  0.10588235408067703 0.89411764591932297;
	setAttr -s 5 ".wl[84].w";
	setAttr ".wl[84].w[9]" 2.135314854388436e-005;
	setAttr ".wl[84].w[10]" 2.1329095489244328e-005;
	setAttr ".wl[84].w[15]" 0.032392627518599046;
	setAttr ".wl[84].w[16]" 0.96751642227172852;
	setAttr ".wl[84].w[21]" 4.8267965639311104e-005;
	setAttr -s 5 ".wl[85].w";
	setAttr ".wl[85].w[9]" 0.00018373348935677033;
	setAttr ".wl[85].w[10]" 0.00018373467471162694;
	setAttr ".wl[85].w[15]" 0.060568653771168483;
	setAttr ".wl[85].w[16]" 0.93900173902511597;
	setAttr ".wl[85].w[21]" 6.2139039647152365e-005;
	setAttr -s 5 ".wl[86].w";
	setAttr ".wl[86].w[9]" 0.00012395236976923624;
	setAttr ".wl[86].w[10]" 0.00012753379890633593;
	setAttr ".wl[86].w[15]" 0.050697623499116759;
	setAttr ".wl[86].w[16]" 0.94901341199874878;
	setAttr ".wl[86].w[21]" 3.7478333458895014e-005;
	setAttr -s 5 ".wl[87].w";
	setAttr ".wl[87].w[9]" 9.9743231405940169e-009;
	setAttr ".wl[87].w[10]" 1.0155948514411104e-008;
	setAttr ".wl[87].w[15]" 1.0275561262782311e-005;
	setAttr ".wl[87].w[16]" 0.99998968839645386;
	setAttr ".wl[87].w[21]" 1.5912011705262489e-008;
	setAttr -s 5 ".wl[88].w";
	setAttr ".wl[88].w[3]" 3.7258973533801508e-005;
	setAttr ".wl[88].w[9]" 0.037135309269093607;
	setAttr ".wl[88].w[10]" 0.96263009309768677;
	setAttr ".wl[88].w[15]" 9.866932984291409e-005;
	setAttr ".wl[88].w[16]" 9.866932984291409e-005;
	setAttr -s 5 ".wl[89].w";
	setAttr ".wl[89].w[3]" 0.00023238478250751398;
	setAttr ".wl[89].w[9]" 0.32806537258974627;
	setAttr ".wl[89].w[10]" 0.67029605123756686;
	setAttr ".wl[89].w[15]" 0.00069428037274850646;
	setAttr ".wl[89].w[16]" 0.00071191101743083712;
	setAttr -s 5 ".wl[90].w";
	setAttr ".wl[90].w[3]" 1.4523374732839175e-005;
	setAttr ".wl[90].w[9]" 0.010635845941021236;
	setAttr ".wl[90].w[10]" 0.98933672904968262;
	setAttr ".wl[90].w[15]" 6.4616917870916382e-006;
	setAttr ".wl[90].w[16]" 6.4399427762152159e-006;
	setAttr -s 5 ".wl[91].w";
	setAttr ".wl[91].w[3]" 0.00045826422912574567;
	setAttr ".wl[91].w[9]" 0.32666046397856541;
	setAttr ".wl[91].w[10]" 0.67228822774201691;
	setAttr ".wl[91].w[15]" 0.00029413970734287227;
	setAttr ".wl[91].w[16]" 0.00029890434294909014;
	setAttr -s 5 ".wl[92].w";
	setAttr ".wl[92].w[10]" 5.8188889015057132e-006;
	setAttr ".wl[92].w[16]" 0.032118712335833861;
	setAttr ".wl[92].w[17]" 0.96786373853683472;
	setAttr ".wl[92].w[22]" 5.8997031065869579e-006;
	setAttr ".wl[92].w[23]" 5.8305353233302571e-006;
	setAttr ".wl[93].w[17]"  1;
	setAttr -s 5 ".wl[94].w";
	setAttr ".wl[94].w[10]" 0.0017201976307645835;
	setAttr ".wl[94].w[11]" 0.001731961568581861;
	setAttr ".wl[94].w[16]" 0.44752815731174489;
	setAttr ".wl[94].w[17]" 0.54864737135504116;
	setAttr ".wl[94].w[18]" 0.00037231213386736443;
	setAttr -s 5 ".wl[95].w";
	setAttr ".wl[95].w[10]" 2.3445851149560528e-006;
	setAttr ".wl[95].w[11]" 2.3534276633679882e-006;
	setAttr ".wl[95].w[16]" 0.0017740410401091817;
	setAttr ".wl[95].w[17]" 0.99821925163269043;
	setAttr ".wl[95].w[22]" 2.0093144220646028e-006;
	setAttr -s 5 ".wl[96].w";
	setAttr ".wl[96].w[10]" 0.0047825986960103005;
	setAttr ".wl[96].w[11]" 0.9951903223991394;
	setAttr ".wl[96].w[12]" 3.0372735813905617e-006;
	setAttr ".wl[96].w[16]" 1.1795017917769654e-005;
	setAttr ".wl[96].w[17]" 1.2246613351135089e-005;
	setAttr -s 5 ".wl[97].w";
	setAttr ".wl[97].w[10]" 0.014163033257085809;
	setAttr ".wl[97].w[11]" 0.98574072122573853;
	setAttr ".wl[97].w[12]" 9.8324651321159152e-006;
	setAttr ".wl[97].w[16]" 4.2809002003706049e-005;
	setAttr ".wl[97].w[17]" 4.3604050039842866e-005;
	setAttr ".wl[98].w[11]"  1;
	setAttr -s 5 ".wl[99].w";
	setAttr ".wl[99].w[4]" 7.9515790621321565e-006;
	setAttr ".wl[99].w[10]" 0.0070030590240402124;
	setAttr ".wl[99].w[11]" 0.99297052621841431;
	setAttr ".wl[99].w[16]" 9.1687972296746332e-006;
	setAttr ".wl[99].w[17]" 9.2943812536738553e-006;
	setAttr -s 5 ".wl[100].w";
	setAttr ".wl[100].w[11]" 1.0111260009693668e-005;
	setAttr ".wl[100].w[12]" 1.0022010779287581e-005;
	setAttr ".wl[100].w[16]" 5.4905005163948689e-006;
	setAttr ".wl[100].w[17]" 0.024284390156739919;
	setAttr ".wl[100].w[18]" 0.97568998608650659;
	setAttr -s 5 ".wl[101].w";
	setAttr ".wl[101].w[11]" 3.0602971122986251e-006;
	setAttr ".wl[101].w[12]" 3.0602971122986251e-006;
	setAttr ".wl[101].w[16]" 4.5165627281452783e-007;
	setAttr ".wl[101].w[17]" 0.002108558331206988;
	setAttr ".wl[101].w[18]" 0.99788490675123409;
	setAttr -s 5 ".wl[102].w";
	setAttr ".wl[102].w[11]" 0.00019713013707925336;
	setAttr ".wl[102].w[12]" 0.00019713013707925336;
	setAttr ".wl[102].w[16]" 3.2628398692143163e-005;
	setAttr ".wl[102].w[17]" 0.060667012663107728;
	setAttr ".wl[102].w[18]" 0.93890610726422352;
	setAttr -s 5 ".wl[103].w";
	setAttr ".wl[103].w[11]" 3.5569391367757556e-005;
	setAttr ".wl[103].w[12]" 3.5569391367757556e-005;
	setAttr ".wl[103].w[16]" 1.419396227289866e-005;
	setAttr ".wl[103].w[17]" 0.017627112588015175;
	setAttr ".wl[103].w[18]" 0.98228757736796413;
	setAttr -s 5 ".wl[104].w";
	setAttr ".wl[104].w[10]" 6.7087692786306247e-007;
	setAttr ".wl[104].w[11]" 0.0019944355289297001;
	setAttr ".wl[104].w[12]" 0.99799428680410385;
	setAttr ".wl[104].w[17]" 5.3034014746772494e-006;
	setAttr ".wl[104].w[18]" 5.3033885638301414e-006;
	setAttr -s 5 ".wl[105].w";
	setAttr ".wl[105].w[10]" 1.5723439540559892e-005;
	setAttr ".wl[105].w[11]" 0.021446995526141124;
	setAttr ".wl[105].w[12]" 0.97831646001479899;
	setAttr ".wl[105].w[17]" 0.00011041653425254728;
	setAttr ".wl[105].w[18]" 0.00011041653425254728;
	setAttr -s 7 ".wl[106].w";
	setAttr ".wl[106].w[4]" 5.9395722047133993e-010;
	setAttr ".wl[106].w[10]" 1.7319655167670599e-006;
	setAttr ".wl[106].w[11]" 0.025942845197807762;
	setAttr ".wl[106].w[12]" 0.97405034623459053;
	setAttr ".wl[106].w[16]" 6.848794780319517e-010;
	setAttr ".wl[106].w[17]" 2.5431886663055856e-006;
	setAttr ".wl[106].w[18]" 2.5321418578427092e-006;
	setAttr -s 7 ".wl[107].w";
	setAttr ".wl[107].w[4]" 3.2118962875673044e-010;
	setAttr ".wl[107].w[10]" 8.2426120772119888e-006;
	setAttr ".wl[107].w[11]" 0.015701218314610049;
	setAttr ".wl[107].w[12]" 0.98424236728064085;
	setAttr ".wl[107].w[16]" 3.7035695115823635e-010;
	setAttr ".wl[107].w[17]" 2.4085250765399613e-005;
	setAttr ".wl[107].w[18]" 2.4084871743559268e-005;
	setAttr -s 7 ".wl[108].w";
	setAttr ".wl[108].w[0]" 0.11661264379907929;
	setAttr ".wl[108].w[13]" 0.051372820607862711;
	setAttr ".wl[108].w[14]" 1.9468194034648341e-005;
	setAttr ".wl[108].w[19]" 0.81932153680411934;
	setAttr ".wl[108].w[20]" 4.2404951484325e-005;
	setAttr ".wl[108].w[25]" 0.0097684656427186045;
	setAttr ".wl[108].w[26]" 0.0028626815666394022;
	setAttr -s 5 ".wl[109].w";
	setAttr ".wl[109].w[0]" 0.35131930300684966;
	setAttr ".wl[109].w[13]" 0.022688900367643653;
	setAttr ".wl[109].w[19]" 0.35131930300684966;
	setAttr ".wl[109].w[25]" 0.22196216868492846;
	setAttr ".wl[109].w[26]" 0.052710324933728583;
	setAttr -s 5 ".wl[110].w";
	setAttr ".wl[110].w[0]" 0.0036442397558099542;
	setAttr ".wl[110].w[13]" 0.00010121786872917717;
	setAttr ".wl[110].w[19]" 0.18422092899514866;
	setAttr ".wl[110].w[25]" 0.61906987428665161;
	setAttr ".wl[110].w[26]" 0.19296373909366063;
	setAttr -s 3 ".wl[111].w";
	setAttr ".wl[111].w[13]" 0.11550942403314113;
	setAttr ".wl[111].w[19]" 0.68056900459291936;
	setAttr ".wl[111].w[25]" 0.20392157137393951;
	setAttr -s 7 ".wl[112].w";
	setAttr ".wl[112].w[0]" 0.34647314509300953;
	setAttr ".wl[112].w[1]" 0.34658613880264261;
	setAttr ".wl[112].w[2]" 7.2709851107966017e-005;
	setAttr ".wl[112].w[7]" 0.024485109786225756;
	setAttr ".wl[112].w[8]" 3.1664490854952948e-007;
	setAttr ".wl[112].w[32]" 0.22255907647242809;
	setAttr ".wl[112].w[33]" 0.05982350334967744;
	setAttr -s 7 ".wl[113].w";
	setAttr ".wl[113].w[0]" 0.0013193522184727757;
	setAttr ".wl[113].w[1]" 0.55416171998470698;
	setAttr ".wl[113].w[2]" 7.6080709238451893e-005;
	setAttr ".wl[113].w[7]" 0.0015722220524260686;
	setAttr ".wl[113].w[8]" 3.313246946884974e-007;
	setAttr ".wl[113].w[32]" 0.43976880898921822;
	setAttr ".wl[113].w[33]" 0.0031014950967583887;
	setAttr -s 5 ".wl[114].w";
	setAttr ".wl[114].w[0]" 0.37414765720510446;
	setAttr ".wl[114].w[1]" 0.45192260870823048;
	setAttr ".wl[114].w[7]" 0.1432487815618515;
	setAttr ".wl[114].w[32]" 0.023326582010194292;
	setAttr ".wl[114].w[33]" 0.0073543705146191553;
	setAttr -s 5 ".wl[115].w";
	setAttr ".wl[115].w[0]" 3.8297108555404286e-005;
	setAttr ".wl[115].w[1]" 0.98436832427978516;
	setAttr ".wl[115].w[2]" 0.00012302951077947653;
	setAttr ".wl[115].w[7]" 8.871282732408519e-005;
	setAttr ".wl[115].w[32]" 0.015381636273555878;
	setAttr -s 5 ".wl[116].w";
	setAttr ".wl[116].w[13]" 0.057009838713488532;
	setAttr ".wl[116].w[14]" 0.057052842878033291;
	setAttr ".wl[116].w[15]" 0.0064538828828138387;
	setAttr ".wl[116].w[19]" 0.43878916597425394;
	setAttr ".wl[116].w[20]" 0.4406942695514105;
	setAttr -s 5 ".wl[117].w";
	setAttr ".wl[117].w[0]" 0.00067560719942818268;
	setAttr ".wl[117].w[13]" 0.0014260092639217805;
	setAttr ".wl[117].w[14]" 0.0013271349595655019;
	setAttr ".wl[117].w[19]" 0.046944504783596984;
	setAttr ".wl[117].w[20]" 0.94962674379348755;
	setAttr -s 5 ".wl[118].w";
	setAttr ".wl[118].w[0]" 0.00087574289442724678;
	setAttr ".wl[118].w[13]" 0.0019580046458040645;
	setAttr ".wl[118].w[14]" 0.02039750003334646;
	setAttr ".wl[118].w[19]" 0.14502806961536407;
	setAttr ".wl[118].w[20]" 0.83174068281105817;
	setAttr -s 5 ".wl[119].w";
	setAttr ".wl[119].w[13]" 3.1729753090271507e-005;
	setAttr ".wl[119].w[14]" 0.0072757893847827963;
	setAttr ".wl[119].w[15]" 7.2024389085002432e-006;
	setAttr ".wl[119].w[19]" 0.00037850952902287473;
	setAttr ".wl[119].w[20]" 0.99230676889419556;
	setAttr -s 5 ".wl[120].w";
	setAttr ".wl[120].w[0]" 0.0026046006629014302;
	setAttr ".wl[120].w[1]" 0.17426483802723827;
	setAttr ".wl[120].w[2]" 0.81541824340820313;
	setAttr ".wl[120].w[7]" 0.0041612442688668226;
	setAttr ".wl[120].w[8]" 0.0035510736327903241;
	setAttr -s 5 ".wl[121].w";
	setAttr ".wl[121].w[1]" 0.063702978193759918;
	setAttr ".wl[121].w[2]" 0.92885345549340159;
	setAttr ".wl[121].w[7]" 0.00053194571519067321;
	setAttr ".wl[121].w[8]" 0.0054040006158665218;
	setAttr ".wl[121].w[32]" 0.0015076199817813313;
	setAttr -s 5 ".wl[122].w";
	setAttr ".wl[122].w[0]" 0.0038311248915758747;
	setAttr ".wl[122].w[1]" 0.23508392766991035;
	setAttr ".wl[122].w[2]" 0.71358400583267212;
	setAttr ".wl[122].w[7]" 0.023538252674646144;
	setAttr ".wl[122].w[8]" 0.02396268893119553;
	setAttr -s 5 ".wl[123].w";
	setAttr ".wl[123].w[1]" 0.00035523896133173868;
	setAttr ".wl[123].w[2]" 0.99609410762786865;
	setAttr ".wl[123].w[3]" 9.4081026122567226e-005;
	setAttr ".wl[123].w[7]" 1.7752029858924553e-005;
	setAttr ".wl[123].w[8]" 0.0034388203548181171;
	setAttr -s 5 ".wl[124].w";
	setAttr ".wl[124].w[14]" 0.0048159623029870226;
	setAttr ".wl[124].w[15]" 0.0084604744811202382;
	setAttr ".wl[124].w[16]" 0.0010276549538129488;
	setAttr ".wl[124].w[20]" 0.52822343170441355;
	setAttr ".wl[124].w[21]" 0.45747247655766615;
	setAttr -s 5 ".wl[125].w";
	setAttr ".wl[125].w[14]" 0.00019161515700909671;
	setAttr ".wl[125].w[15]" 0.0002384087987485857;
	setAttr ".wl[125].w[19]" 6.171492435883447e-005;
	setAttr ".wl[125].w[20]" 0.073070771992206573;
	setAttr ".wl[125].w[21]" 0.92643748912767687;
	setAttr -s 5 ".wl[126].w";
	setAttr ".wl[126].w[14]" 4.1037626167589358e-005;
	setAttr ".wl[126].w[15]" 5.0612195847851082e-005;
	setAttr ".wl[126].w[20]" 0.0095367193131722476;
	setAttr ".wl[126].w[21]" 0.9903564453125;
	setAttr ".wl[126].w[22]" 1.5185552312310651e-005;
	setAttr -s 5 ".wl[127].w";
	setAttr ".wl[127].w[14]" 0.00023058112805873426;
	setAttr ".wl[127].w[15]" 0.0003570940211875796;
	setAttr ".wl[127].w[16]" 7.8601758468137541e-005;
	setAttr ".wl[127].w[20]" 0.028339787030426417;
	setAttr ".wl[127].w[21]" 0.97099393606185913;
	setAttr -s 5 ".wl[128].w";
	setAttr ".wl[128].w[1]" 4.7858101325348165e-005;
	setAttr ".wl[128].w[2]" 0.051324218809315078;
	setAttr ".wl[128].w[3]" 0.94829583168029785;
	setAttr ".wl[128].w[8]" 0.00014764716114098938;
	setAttr ".wl[128].w[9]" 0.00018444424792073011;
	setAttr -s 5 ".wl[129].w";
	setAttr ".wl[129].w[2]" 2.9646236219862719e-005;
	setAttr ".wl[129].w[3]" 0.99997001886367798;
	setAttr ".wl[129].w[8]" 1.2960529105483622e-007;
	setAttr ".wl[129].w[9]" 1.5999768425363167e-007;
	setAttr ".wl[129].w[10]" 4.5297126850299562e-008;
	setAttr -s 5 ".wl[130].w";
	setAttr ".wl[130].w[2]" 0.0079806302353256225;
	setAttr ".wl[130].w[3]" 0.99175703525543213;
	setAttr ".wl[130].w[8]" 8.7731900109780795e-005;
	setAttr ".wl[130].w[9]" 0.00015642060090460903;
	setAttr ".wl[130].w[10]" 1.8182008227860071e-005;
	setAttr -s 5 ".wl[131].w";
	setAttr ".wl[131].w[2]" 0.0024036817838925919;
	setAttr ".wl[131].w[3]" 0.99753254652023315;
	setAttr ".wl[131].w[8]" 2.2171737259768712e-005;
	setAttr ".wl[131].w[9]" 3.4347230037021219e-005;
	setAttr ".wl[131].w[10]" 7.2527285774642027e-006;
	setAttr -s 5 ".wl[132].w";
	setAttr ".wl[132].w[15]" 0.0013256733907171204;
	setAttr ".wl[132].w[16]" 0.0016237887961420203;
	setAttr ".wl[132].w[21]" 0.18824467955450297;
	setAttr ".wl[132].w[22]" 0.80656013163240059;
	setAttr ".wl[132].w[23]" 0.0022457266262372565;
	setAttr -s 5 ".wl[133].w";
	setAttr ".wl[133].w[15]" 0.00010091767925536641;
	setAttr ".wl[133].w[16]" 0.00011037970122125761;
	setAttr ".wl[133].w[21]" 0.025559066231199499;
	setAttr ".wl[133].w[22]" 0.9735979437828064;
	setAttr ".wl[133].w[23]" 0.00063169260551747817;
	setAttr -s 5 ".wl[134].w";
	setAttr ".wl[134].w[15]" 2.1142512875824213e-005;
	setAttr ".wl[134].w[16]" 2.1142512875824213e-005;
	setAttr ".wl[134].w[21]" 0.023494209642249724;
	setAttr ".wl[134].w[22]" 0.97643542289733887;
	setAttr ".wl[134].w[23]" 2.808243465976081e-005;
	setAttr -s 5 ".wl[135].w";
	setAttr ".wl[135].w[15]" 4.8621783886787032e-005;
	setAttr ".wl[135].w[16]" 4.8765193135834946e-005;
	setAttr ".wl[135].w[21]" 0.045041998916089683;
	setAttr ".wl[135].w[22]" 0.95482742786407471;
	setAttr ".wl[135].w[23]" 3.3186242812989378e-005;
	setAttr -s 5 ".wl[136].w";
	setAttr ".wl[136].w[3]" 0.33771092574251238;
	setAttr ".wl[136].w[4]" 0.62361604725285313;
	setAttr ".wl[136].w[5]" 0.035741526633501053;
	setAttr ".wl[136].w[9]" 0.0014029842812887413;
	setAttr ".wl[136].w[10]" 0.0015285160898447353;
	setAttr -s 5 ".wl[137].w";
	setAttr ".wl[137].w[3]" 0.034954678581602838;
	setAttr ".wl[137].w[4]" 0.96436643600463867;
	setAttr ".wl[137].w[5]" 0.00060298674770575605;
	setAttr ".wl[137].w[9]" 3.7949333026362887e-005;
	setAttr ".wl[137].w[10]" 3.7949333026362887e-005;
	setAttr -s 5 ".wl[138].w";
	setAttr ".wl[138].w[3]" 0.026069914264246676;
	setAttr ".wl[138].w[4]" 0.94581513505279424;
	setAttr ".wl[138].w[5]" 0.027734285220503807;
	setAttr ".wl[138].w[9]" 0.00017150598361849814;
	setAttr ".wl[138].w[10]" 0.00020915947883678822;
	setAttr -s 5 ".wl[139].w";
	setAttr ".wl[139].w[3]" 0.013583837054465468;
	setAttr ".wl[139].w[4]" 0.98224204249362823;
	setAttr ".wl[139].w[5]" 0.004145527258515358;
	setAttr ".wl[139].w[9]" 1.4282134357567786e-005;
	setAttr ".wl[139].w[10]" 1.4311059033344184e-005;
	setAttr -s 5 ".wl[140].w";
	setAttr ".wl[140].w[16]" 0.0031160461397042394;
	setAttr ".wl[140].w[17]" 0.0033252736540748513;
	setAttr ".wl[140].w[22]" 0.4848129430151063;
	setAttr ".wl[140].w[23]" 0.50744044737151528;
	setAttr ".wl[140].w[24]" 0.0013052898195994108;
	setAttr -s 5 ".wl[141].w";
	setAttr ".wl[141].w[16]" 7.8514753643593239e-005;
	setAttr ".wl[141].w[17]" 7.9532400463851719e-005;
	setAttr ".wl[141].w[22]" 0.035797199086053319;
	setAttr ".wl[141].w[23]" 0.96395325660705566;
	setAttr ".wl[141].w[24]" 9.1497152783570905e-005;
	setAttr -s 5 ".wl[142].w";
	setAttr ".wl[142].w[16]" 3.9826714920877769e-005;
	setAttr ".wl[142].w[21]" 0.00014207669409357817;
	setAttr ".wl[142].w[22]" 0.12395577877759933;
	setAttr ".wl[142].w[23]" 0.87582041907153863;
	setAttr ".wl[142].w[24]" 4.1898741847598763e-005;
	setAttr -s 5 ".wl[143].w";
	setAttr ".wl[143].w[16]" 0.00035964752871147976;
	setAttr ".wl[143].w[17]" 0.00035591527058141735;
	setAttr ".wl[143].w[21]" 0.00045282056737932613;
	setAttr ".wl[143].w[22]" 0.2033434379033168;
	setAttr ".wl[143].w[23]" 0.79548817873001099;
	setAttr -s 5 ".wl[144].w";
	setAttr ".wl[144].w[4]" 0.1813146366846411;
	setAttr ".wl[144].w[5]" 0.81725412607192993;
	setAttr ".wl[144].w[6]" 0.00051364288215933064;
	setAttr ".wl[144].w[10]" 0.00045230442476453534;
	setAttr ".wl[144].w[11]" 0.00046528993650509062;
	setAttr ".wl[145].w[5]"  1;
	setAttr -s 5 ".wl[146].w";
	setAttr ".wl[146].w[4]" 0.051503862334454656;
	setAttr ".wl[146].w[5]" 0.94766026735305786;
	setAttr ".wl[146].w[6]" 0.00013555016627356698;
	setAttr ".wl[146].w[10]" 0.00033332834240642475;
	setAttr ".wl[146].w[11]" 0.00036699180380748883;
	setAttr -s 5 ".wl[147].w";
	setAttr ".wl[147].w[3]" 2.3262505478725692e-007;
	setAttr ".wl[147].w[4]" 0.00024462606932191172;
	setAttr ".wl[147].w[5]" 0.99975478649139404;
	setAttr ".wl[147].w[10]" 1.7764374998203313e-007;
	setAttr ".wl[147].w[11]" 1.7717047927598915e-007;
	setAttr -s 6 ".wl[148].w";
	setAttr ".wl[148].w[16]" 3.0572642505795783e-007;
	setAttr ".wl[148].w[17]" 3.3812124318253615e-007;
	setAttr ".wl[148].w[18]" 1.1866019462363914e-008;
	setAttr ".wl[148].w[22]" 4.7586295461464642e-005;
	setAttr ".wl[148].w[23]" 7.0703327070622272e-005;
	setAttr ".wl[148].w[24]" 0.9998810669528726;
	setAttr -s 6 ".wl[149].w";
	setAttr ".wl[149].w[16]" 1.7643613143783008e-009;
	setAttr ".wl[149].w[17]" 0.00031964014647388353;
	setAttr ".wl[149].w[18]" 0.0003196383592442979;
	setAttr ".wl[149].w[22]" 0.00072528118271592923;
	setAttr ".wl[149].w[23]" 0.16006950875442522;
	setAttr ".wl[149].w[24]" 0.83856590704267886;
	setAttr -s 7 ".wl[150].w";
	setAttr ".wl[150].w[16]" 5.0346832122171214e-010;
	setAttr ".wl[150].w[17]" 2.2840712755790449e-005;
	setAttr ".wl[150].w[18]" 2.2745629114984046e-005;
	setAttr ".wl[150].w[21]" 1.7960586205046717e-009;
	setAttr ".wl[150].w[22]" 8.1402278502529568e-005;
	setAttr ".wl[150].w[23]" 0.049063800700733268;
	setAttr ".wl[150].w[24]" 0.95080921052395495;
	setAttr -s 6 ".wl[151].w";
	setAttr ".wl[151].w[16]" 3.6100793949167877e-007;
	setAttr ".wl[151].w[17]" 5.69590636540655e-005;
	setAttr ".wl[151].w[18]" 5.6570291001651665e-005;
	setAttr ".wl[151].w[22]" 0.00014944069945593621;
	setAttr ".wl[151].w[23]" 0.099776663941057095;
	setAttr ".wl[151].w[24]" 0.89996000499689177;
	setAttr -s 6 ".wl[152].w";
	setAttr ".wl[152].w[4]" 0.00058713635638966229;
	setAttr ".wl[152].w[5]" 0.11709102457958454;
	setAttr ".wl[152].w[6]" 0.88174298920170069;
	setAttr ".wl[152].w[10]" 2.8214855598370923e-008;
	setAttr ".wl[152].w[11]" 0.00028940962768086309;
	setAttr ".wl[152].w[12]" 0.00028938060220362925;
	setAttr -s 6 ".wl[153].w";
	setAttr ".wl[153].w[4]" 5.4674432240932654e-005;
	setAttr ".wl[153].w[5]" 0.029530492537095533;
	setAttr ".wl[153].w[6]" 0.97038874308352741;
	setAttr ".wl[153].w[10]" 3.5426335891138476e-008;
	setAttr ".wl[153].w[11]" 1.3046630233854508e-005;
	setAttr ".wl[153].w[12]" 1.3007890566378422e-005;
	setAttr -s 5 ".wl[154].w";
	setAttr ".wl[154].w[4]" 0.00034000352557658666;
	setAttr ".wl[154].w[5]" 0.077865987365242931;
	setAttr ".wl[154].w[6]" 0.92097360901632053;
	setAttr ".wl[154].w[11]" 0.00041021182620532324;
	setAttr ".wl[154].w[12]" 0.00041021182620532324;
	setAttr -s 5 ".wl[155].w";
	setAttr ".wl[155].w[4]" 6.6680421968722881e-005;
	setAttr ".wl[155].w[5]" 0.080753286589780329;
	setAttr ".wl[155].w[6]" 0.91908781222542035;
	setAttr ".wl[155].w[11]" 4.6125810453820953e-005;
	setAttr ".wl[155].w[12]" 4.6125809712969644e-005;
	setAttr -s 6 ".wl[156].w";
	setAttr ".wl[156].w[0]" 0.00035361923704444815;
	setAttr ".wl[156].w[13]" 4.2561888762108125e-008;
	setAttr ".wl[156].w[19]" 0.031564664995966454;
	setAttr ".wl[156].w[25]" 0.74748845956003329;
	setAttr ".wl[156].w[26]" 0.21780950829387802;
	setAttr ".wl[156].w[27]" 0.0027836624812467691;
	setAttr -s 5 ".wl[157].w";
	setAttr ".wl[157].w[0]" 0.0038390888066185823;
	setAttr ".wl[157].w[19]" 0.37246653437614441;
	setAttr ".wl[157].w[25]" 0.10328217484385922;
	setAttr ".wl[157].w[26]" 0.51714974687633253;
	setAttr ".wl[157].w[27]" 0.0032624550970453007;
	setAttr -s 6 ".wl[158].w";
	setAttr ".wl[158].w[0]" 0.00025949787358914094;
	setAttr ".wl[158].w[13]" 7.0201084163038506e-007;
	setAttr ".wl[158].w[19]" 0.018496356056661733;
	setAttr ".wl[158].w[25]" 0.84839202249854306;
	setAttr ".wl[158].w[26]" 0.13120690378964475;
	setAttr ".wl[158].w[27]" 0.0016445244063929396;
	setAttr -s 6 ".wl[159].w";
	setAttr ".wl[159].w[0]" 0.00047817406292417427;
	setAttr ".wl[159].w[13]" 9.7526337828110285e-007;
	setAttr ".wl[159].w[19]" 0.065522510535356265;
	setAttr ".wl[159].w[25]" 0.83935116493219575;
	setAttr ".wl[159].w[26]" 0.094016809103066826;
	setAttr ".wl[159].w[27]" 0.00063035025604302945;
	setAttr -s 5 ".wl[160].w";
	setAttr ".wl[160].w[0]" 0.056808783127929703;
	setAttr ".wl[160].w[19]" 0.48033821582794189;
	setAttr ".wl[160].w[25]" 0.16626208985513266;
	setAttr ".wl[160].w[26]" 0.29310682157921036;
	setAttr ".wl[160].w[27]" 0.0034840896097853634;
	setAttr -s 6 ".wl[161].w";
	setAttr ".wl[161].w[0]" 0.11530197082889229;
	setAttr ".wl[161].w[13]" 6.9403827058206543e-007;
	setAttr ".wl[161].w[19]" 0.021342014880507673;
	setAttr ".wl[161].w[25]" 0.81142579557439787;
	setAttr ".wl[161].w[26]" 0.049426282575872303;
	setAttr ".wl[161].w[27]" 0.0025032262550235261;
	setAttr -s 5 ".wl[162].w";
	setAttr ".wl[162].w[0]" 0.020943236318703862;
	setAttr ".wl[162].w[1]" 0.0031831741490667914;
	setAttr ".wl[162].w[32]" 0.12619307620999706;
	setAttr ".wl[162].w[33]" 0.83240521717059424;
	setAttr ".wl[162].w[34]" 0.017275296151638031;
	setAttr -s 5 ".wl[163].w";
	setAttr ".wl[163].w[0]" 6.444335532426279e-005;
	setAttr ".wl[163].w[1]" 0.019144550381136903;
	setAttr ".wl[163].w[32]" 0.081818082022109037;
	setAttr ".wl[163].w[33]" 0.87101223093566671;
	setAttr ".wl[163].w[34]" 0.027960698428037216;
	setAttr -s 5 ".wl[164].w";
	setAttr ".wl[164].w[0]" 0.12766343211790962;
	setAttr ".wl[164].w[1]" 0.12766343211790962;
	setAttr ".wl[164].w[32]" 0.53158189579326576;
	setAttr ".wl[164].w[33]" 0.20524810225217793;
	setAttr ".wl[164].w[34]" 0.0078431377187371254;
	setAttr -s 6 ".wl[165].w";
	setAttr ".wl[165].w[0]" 1.6672740829178079e-005;
	setAttr ".wl[165].w[1]" 0.0003148129116102043;
	setAttr ".wl[165].w[7]" 0.0020379268027873455;
	setAttr ".wl[165].w[32]" 0.53428769722910929;
	setAttr ".wl[165].w[33]" 0.45152238356445767;
	setAttr ".wl[165].w[34]" 0.011820512164518666;
	setAttr -s 5 ".wl[166].w";
	setAttr ".wl[166].w[0]" 7.2036795071306467e-005;
	setAttr ".wl[166].w[1]" 0.019594687051300869;
	setAttr ".wl[166].w[32]" 0.079970554048029441;
	setAttr ".wl[166].w[33]" 0.86448735558290057;
	setAttr ".wl[166].w[34]" 0.035875344665721044;
	setAttr -s 5 ".wl[167].w";
	setAttr ".wl[167].w[1]" 0.16527946844146607;
	setAttr ".wl[167].w[7]" 0.0008028355364124442;
	setAttr ".wl[167].w[32]" 0.17543627241783435;
	setAttr ".wl[167].w[33]" 0.63493030457910271;
	setAttr ".wl[167].w[34]" 0.023551097459246061;
	setAttr -s 5 ".wl[168].w";
	setAttr ".wl[168].w[0]" 3.6235357943379236e-005;
	setAttr ".wl[168].w[19]" 0.058859258890151978;
	setAttr ".wl[168].w[25]" 0.063730699226384843;
	setAttr ".wl[168].w[26]" 0.85358081209076864;
	setAttr ".wl[168].w[27]" 0.023792994434751167;
	setAttr -s 2 ".wl[169].w";
	setAttr ".wl[169].w[19]" 0.22745098173618317;
	setAttr ".wl[169].w[26]" 0.77254901826381683;
	setAttr -s 5 ".wl[170].w";
	setAttr ".wl[170].w[0]" 9.4884668382001162e-005;
	setAttr ".wl[170].w[19]" 0.013628139029281153;
	setAttr ".wl[170].w[25]" 0.79782289266586304;
	setAttr ".wl[170].w[26]" 0.18315908222054594;
	setAttr ".wl[170].w[27]" 0.0052950014159278734;
	setAttr -s 3 ".wl[171].w";
	setAttr ".wl[171].w[19]" 0.045028832500506155;
	setAttr ".wl[171].w[25]" 0.81176471710205078;
	setAttr ".wl[171].w[26]" 0.14320645039744306;
	setAttr -s 5 ".wl[172].w";
	setAttr ".wl[172].w[0]" 0.00018197583370783586;
	setAttr ".wl[172].w[19]" 0.12959374487400055;
	setAttr ".wl[172].w[25]" 0.0066344661847145582;
	setAttr ".wl[172].w[26]" 0.86162326467914241;
	setAttr ".wl[172].w[27]" 0.0019665484284346634;
	setAttr -s 5 ".wl[173].w";
	setAttr ".wl[173].w[0]" 0.0015377168406379049;
	setAttr ".wl[173].w[19]" 0.0013392743122380034;
	setAttr ".wl[173].w[25]" 0.61921600762891316;
	setAttr ".wl[173].w[26]" 0.37673715824415899;
	setAttr ".wl[173].w[27]" 0.0011698429740520551;
	setAttr -s 7 ".wl[174].w";
	setAttr ".wl[174].w[0]" 1.3475147150958601e-009;
	setAttr ".wl[174].w[1]" 3.7646941706126446e-008;
	setAttr ".wl[174].w[7]" 2.1411951175250088e-007;
	setAttr ".wl[174].w[32]" 2.596598133423548e-006;
	setAttr ".wl[174].w[33]" 0.80847517734741281;
	setAttr ".wl[174].w[34]" 0.19152197157643697;
	setAttr ".wl[174].w[35]" 1.364958100625113e-009;
	setAttr -s 4 ".wl[175].w";
	setAttr ".wl[175].w[1]" 0.00029679339671612615;
	setAttr ".wl[175].w[32]" 0.0011622763308471002;
	setAttr ".wl[175].w[33]" 0.83761435107141546;
	setAttr ".wl[175].w[34]" 0.16092657920102127;
	setAttr -s 5 ".wl[176].w";
	setAttr ".wl[176].w[1]" 0.0025308649354943802;
	setAttr ".wl[176].w[7]" 0.014394464456893571;
	setAttr ".wl[176].w[32]" 0.17382598617046952;
	setAttr ".wl[176].w[33]" 0.68943805107580303;
	setAttr ".wl[176].w[34]" 0.11981063336133957;
	setAttr -s 5 ".wl[177].w";
	setAttr ".wl[177].w[1]" 1.8643655855529872e-006;
	setAttr ".wl[177].w[7]" 0.00023069027925056259;
	setAttr ".wl[177].w[32]" 0.030800438972360449;
	setAttr ".wl[177].w[33]" 0.8551621668313546;
	setAttr ".wl[177].w[34]" 0.11380483955144882;
	setAttr -s 5 ".wl[178].w";
	setAttr ".wl[178].w[1]" 0.0011673789678446388;
	setAttr ".wl[178].w[32]" 0.004799987889066353;
	setAttr ".wl[178].w[33]" 0.85663138654835091;
	setAttr ".wl[178].w[34]" 0.13740106797848789;
	setAttr ".wl[178].w[35]" 1.9793391765101634e-007;
	setAttr -s 6 ".wl[179].w";
	setAttr ".wl[179].w[1]" 0.013773003496697307;
	setAttr ".wl[179].w[7]" 0.0001174985838815394;
	setAttr ".wl[179].w[32]" 0.020696815486527485;
	setAttr ".wl[179].w[33]" 0.77518016625245478;
	setAttr ".wl[179].w[34]" 0.19022986359289681;
	setAttr ".wl[179].w[35]" 2.6525884515342596e-006;
	setAttr -s 2 ".wl[180].w[26:27]"  0.078431375324726105 0.9215686246752739;
	setAttr -s 2 ".wl[181].w[26:27]"  0.098039217293262482 0.90196078270673752;
	setAttr -s 2 ".wl[182].w[26:27]"  0.23921568691730499 0.76078431308269501;
	setAttr -s 2 ".wl[183].w[26:27]"  0.31372550129890442 0.68627449870109558;
	setAttr -s 2 ".wl[184].w[26:27]"  0.10196078568696976 0.89803921431303024;
	setAttr -s 5 ".wl[185].w";
	setAttr ".wl[185].w[0]" 0.00044203791713776384;
	setAttr ".wl[185].w[19]" 0.00044203791713776384;
	setAttr ".wl[185].w[25]" 0.0033190113210606522;
	setAttr ".wl[185].w[26]" 0.49789845642233199;
	setAttr ".wl[185].w[27]" 0.49789845642233199;
	setAttr -s 5 ".wl[186].w";
	setAttr ".wl[186].w[0]" 7.9451934043798739e-006;
	setAttr ".wl[186].w[32]" 6.4352197783319585e-005;
	setAttr ".wl[186].w[33]" 0.011958421903813139;
	setAttr ".wl[186].w[34]" 0.98796123266220093;
	setAttr ".wl[186].w[35]" 8.0480427982339627e-006;
	setAttr ".wl[187].w[34]"  1;
	setAttr -s 5 ".wl[188].w";
	setAttr ".wl[188].w[1]" 1.0130045778857274e-006;
	setAttr ".wl[188].w[32]" 5.0530932228214976e-006;
	setAttr ".wl[188].w[33]" 0.0014131736997369858;
	setAttr ".wl[188].w[34]" 0.99857783317565918;
	setAttr ".wl[188].w[35]" 2.9270268031272311e-006;
	setAttr -s 5 ".wl[189].w";
	setAttr ".wl[189].w[0]" 4.2093552491424744e-010;
	setAttr ".wl[189].w[32]" 1.6161056666453593e-005;
	setAttr ".wl[189].w[33]" 0.00014624159802661767;
	setAttr ".wl[189].w[34]" 0.9919944126395055;
	setAttr ".wl[189].w[35]" 0.0078431842848658562;
	setAttr ".wl[190].w[34]"  1;
	setAttr -s 5 ".wl[191].w";
	setAttr ".wl[191].w[1]" 3.5774716922862744e-010;
	setAttr ".wl[191].w[32]" 2.4408005792526073e-005;
	setAttr ".wl[191].w[33]" 0.0010576200658465773;
	setAttr ".wl[191].w[34]" 0.98327782454026014;
	setAttr ".wl[191].w[35]" 0.015640147030353546;
	setAttr ".wl[192].w[28]"  1;
	setAttr -s 3 ".wl[193].w[27:29]"  0.011764706112444401 0.98780977562737204 
		0.00042551826018355499;
	setAttr ".wl[194].w[28]"  1;
	setAttr -s 3 ".wl[195].w[27:29]"  0.0078431377187371254 0.9920042884153315 
		0.00015257386593137134;
	setAttr -s 3 ".wl[196].w[27:29]"  0.0078431377187371254 0.98776255753096742 
		0.0043943047502955079;
	setAttr ".wl[197].w[28]"  1;
	setAttr ".wl[198].w[35]"  1;
	setAttr -s 5 ".wl[199].w[32:36]"  5.3266907858746091e-010 3.6650752929788323e-009 
		7.8613813042242924e-006 0.99999213218688965 2.2340617557050458e-009;
	setAttr -s 5 ".wl[200].w[32:36]"  3.3217455113834815e-007 2.0469451331293267e-006 
		0.00045940668737190059 0.99561064761619478 0.0039275665767490864;
	setAttr -s 2 ".wl[201].w[35:36]"  0.99607843114063144 0.0039215688593685627;
	setAttr -s 5 ".wl[202].w[32:36]"  9.570779628332904e-008 6.1794905076399131e-007 
		0.00018251100676857263 0.99981635808944702 4.1724693735856987e-007;
	setAttr ".wl[203].w[35]"  1;
	setAttr ".wl[204].w[29]"  1;
	setAttr -s 2 ".wl[205].w[28:29]"  0.0052748918533325195 0.99472510814666748;
	setAttr -s 2 ".wl[206].w[28:29]"  0.010795831680297852 0.98920416831970215;
	setAttr -s 2 ".wl[207].w[28:29]"  0.013840854167938232 0.98615914583206177;
	setAttr -s 5 ".wl[208].w";
	setAttr ".wl[208].w[20]" 5.5990273363593192e-006;
	setAttr ".wl[208].w[27]" 6.0102210095005786e-005;
	setAttr ".wl[208].w[28]" 0.026800973786766338;
	setAttr ".wl[208].w[29]" 0.97311025857925415;
	setAttr ".wl[208].w[30]" 2.3066396548145461e-005;
	setAttr ".wl[209].w[29]"  1;
	setAttr ".wl[210].w[36]"  1;
	setAttr -s 5 ".wl[211].w[33:37]"  8.9335439582576549e-009 9.5693712798353895e-008 
		0.00030181818434022812 0.99969804286956787 3.4318835144135138e-008;
	setAttr ".wl[212].w[36]"  1;
	setAttr ".wl[213].w[36]"  1;
	setAttr -s 5 ".wl[214].w[33:37]"  3.7611618885470194e-008 3.8264962237157144e-007 
		0.00015499384777460423 0.99984449148178101 9.440920313286714e-008;
	setAttr -s 5 ".wl[215].w[33:37]"  2.7400725164177551e-007 2.419909316286579e-006 
		0.0012334762167529442 0.99876326322555542 5.6664112370758855e-007;
	setAttr ".wl[216].w[30]"  1;
	setAttr -s 4 ".wl[217].w";
	setAttr ".wl[217].w[20]" 1.5446418678334528e-006;
	setAttr ".wl[217].w[28]" 6.8808925096456715e-006;
	setAttr ".wl[217].w[29]" 0.021521725832810021;
	setAttr ".wl[217].w[30]" 0.9784698486328125;
	setAttr -s 5 ".wl[218].w[27:31]"  0.00016262875655209915 0.00026441774475249337 
		0.0015587344607935435 0.99769318103790283 0.00032103799999903197;
	setAttr -s 4 ".wl[219].w";
	setAttr ".wl[219].w[20]" 1.8784758202437946e-006;
	setAttr ".wl[219].w[28]" 1.1086590371389418e-005;
	setAttr ".wl[219].w[29]" 0.018441467421296161;
	setAttr ".wl[219].w[30]" 0.98154556751251221;
	setAttr -s 4 ".wl[220].w";
	setAttr ".wl[220].w[20]" 6.1101008820308141e-005;
	setAttr ".wl[220].w[28]" 0.00023010295118859974;
	setAttr ".wl[220].w[29]" 0.18794407893794032;
	setAttr ".wl[220].w[30]" 0.81176471710205078;
	setAttr ".wl[221].w[30]"  1;
	setAttr ".wl[222].w[37]"  1;
	setAttr -s 5 ".wl[223].w[34:38]"  9.508849840069276e-010 6.3052663271520677e-009 
		6.0534457524789193e-005 0.9999394416809082 1.660541569652615e-008;
	setAttr -s 5 ".wl[224].w";
	setAttr ".wl[224].w[2]" 1.3416841275819518e-006;
	setAttr ".wl[224].w[35]" 5.368059187845193e-006;
	setAttr ".wl[224].w[36]" 0.0036358222328020983;
	setAttr ".wl[224].w[37]" 0.99632453918457031;
	setAttr ".wl[224].w[38]" 3.2928839312161872e-005;
	setAttr -s 5 ".wl[225].w";
	setAttr ".wl[225].w[2]" 3.0000274715747073e-007;
	setAttr ".wl[225].w[35]" 1.4310587455763624e-006;
	setAttr ".wl[225].w[36]" 0.0034542292311053762;
	setAttr ".wl[225].w[37]" 0.99653708934783936;
	setAttr ".wl[225].w[38]" 6.9503595625346108e-006;
	setAttr -s 5 ".wl[226].w[34:38]"  7.114672837878309e-008 5.4538206993713011e-007 
		0.0019139891992558781 0.99808430671691895 1.0875550268607823e-006;
	setAttr -s 5 ".wl[227].w";
	setAttr ".wl[227].w[2]" 7.1840486733263008e-010;
	setAttr ".wl[227].w[35]" 4.6093503811985033e-009;
	setAttr ".wl[227].w[36]" 7.1343691468310794e-006;
	setAttr ".wl[227].w[37]" 0.99999284744262695;
	setAttr ".wl[227].w[38]" 1.2860470967264468e-008;
	setAttr -s 4 ".wl[228].w";
	setAttr ".wl[228].w[22]" 0.0094681390825440068;
	setAttr ".wl[228].w[23]" 0.0094471596501987682;
	setAttr ".wl[228].w[29]" 0.019013208186949161;
	setAttr ".wl[228].w[31]" 0.96207150320844104;
	setAttr -s 7 ".wl[229].w";
	setAttr ".wl[229].w[20]" 1.7598481333077084e-010;
	setAttr ".wl[229].w[22]" 8.1783634160228819e-005;
	setAttr ".wl[229].w[23]" 8.1071396976497298e-005;
	setAttr ".wl[229].w[28]" 7.8395685697524971e-010;
	setAttr ".wl[229].w[29]" 0.00059355338877067551;
	setAttr ".wl[229].w[30]" 0.00011147945504219603;
	setAttr ".wl[229].w[31]" 0.99913213912661392;
	setAttr -s 7 ".wl[230].w";
	setAttr ".wl[230].w[20]" 2.4200840845305624e-011;
	setAttr ".wl[230].w[22]" 0.0049708666815399148;
	setAttr ".wl[230].w[23]" 0.004913779547570914;
	setAttr ".wl[230].w[28]" 1.4283112202118823e-010;
	setAttr ".wl[230].w[29]" 0.0095826191709834346;
	setAttr ".wl[230].w[30]" 1.2645479811767071e-005;
	setAttr ".wl[230].w[31]" 0.98052008896761389;
	setAttr -s 7 ".wl[231].w";
	setAttr ".wl[231].w[20]" 1.7598481333077084e-010;
	setAttr ".wl[231].w[22]" 0.00035503041207755642;
	setAttr ".wl[231].w[23]" 0.00033547853116361982;
	setAttr ".wl[231].w[28]" 7.8395685697524971e-010;
	setAttr ".wl[231].w[29]" 0.0020728781856448114;
	setAttr ".wl[231].w[30]" 0.00011147945504219603;
	setAttr ".wl[231].w[31]" 0.99712513244885426;
	setAttr -s 7 ".wl[232].w";
	setAttr ".wl[232].w[20]" 6.9613877681845175e-009;
	setAttr ".wl[232].w[22]" 0.00062510605386875001;
	setAttr ".wl[232].w[23]" 0.00062506630481099553;
	setAttr ".wl[232].w[28]" 2.6216193492619966e-008;
	setAttr ".wl[232].w[29]" 0.0047718841608120326;
	setAttr ".wl[232].w[30]" 9.2486344847382551e-005;
	setAttr ".wl[232].w[31]" 0.99388544017618907;
	setAttr -s 7 ".wl[233].w";
	setAttr ".wl[233].w[20]" 7.8717850611246231e-010;
	setAttr ".wl[233].w[22]" 1.7286542738979323e-007;
	setAttr ".wl[233].w[23]" 1.7285458100175652e-007;
	setAttr ".wl[233].w[28]" 2.9644698322641754e-009;
	setAttr ".wl[233].w[29]" 3.7350182139049337e-006;
	setAttr ".wl[233].w[30]" 0.018275069112994216;
	setAttr ".wl[233].w[31]" 0.98172085502642092;
	setAttr -s 2 ".wl[234].w[37:38]"  8.0847690696828067e-005 0.99991916699218564;
	setAttr -s 5 ".wl[235].w[34:38]"  7.687682740085503e-014 5.097660382713133e-013 
		4.8940693366798449e-009 8.0842765594509036e-005 0.99991917610302705;
	setAttr ".wl[236].w[38]"  1.0000000189320417;
	setAttr ".wl[237].w[38]"  1.0000000550062396;
	setAttr -s 5 ".wl[238].w[34:38]"  7.6876820482256194e-014 5.0976599239446279e-013 
		4.8940688962336973e-009 8.0842758318992042e-005 0.9999191523543014;
	setAttr ".wl[239].w[38]"  0.99999999537249096;
	setAttr -s 8 ".wl[240].w";
	setAttr ".wl[240].w[0]" 0.067535710809850255;
	setAttr ".wl[240].w[1]" 0.012435120212993811;
	setAttr ".wl[240].w[7]" 0.079588827093199657;
	setAttr ".wl[240].w[8]" 0.02083413145184318;
	setAttr ".wl[240].w[13]" 0.78530934452816847;
	setAttr ".wl[240].w[14]" 0.016488128634683633;
	setAttr ".wl[240].w[19]" 0.015663643930459908;
	setAttr ".wl[240].w[25]" 0.0021451231411234728;
	setAttr -s 8 ".wl[241].w";
	setAttr ".wl[241].w[0]" 0.17140398782215646;
	setAttr ".wl[241].w[1]" 2.5288772068295868e-005;
	setAttr ".wl[241].w[7]" 0.015367363583969286;
	setAttr ".wl[241].w[13]" 0.6765570722359644;
	setAttr ".wl[241].w[14]" 0.014224661793114291;
	setAttr ".wl[241].w[19]" 0.06904336452433657;
	setAttr ".wl[241].w[25]" 0.053353430911036975;
	setAttr ".wl[241].w[32]" 2.4830619288100704e-005;
	setAttr -s 6 ".wl[242].w";
	setAttr ".wl[242].w[0]" 0.062114953781097729;
	setAttr ".wl[242].w[7]" 2.3644479817127537e-006;
	setAttr ".wl[242].w[13]" 0.79473043501042562;
	setAttr ".wl[242].w[14]" 0.02766540436058193;
	setAttr ".wl[242].w[19]" 0.095862385009781254;
	setAttr ".wl[242].w[25]" 0.019624459085429938;
	setAttr -s 5 ".wl[243].w";
	setAttr ".wl[243].w[0]" 0.043261162859878709;
	setAttr ".wl[243].w[1]" 0.36868902050828856;
	setAttr ".wl[243].w[7]" 0.30176143596166588;
	setAttr ".wl[243].w[13]" 0.079714786409266228;
	setAttr ".wl[243].w[32]" 0.20657358034926965;
	setAttr -s 5 ".wl[244].w";
	setAttr ".wl[244].w[0]" 0.15854291566340564;
	setAttr ".wl[244].w[1]" 0.13161719331366273;
	setAttr ".wl[244].w[7]" 0.4218083048834062;
	setAttr ".wl[244].w[13]" 0.17376692133977414;
	setAttr ".wl[244].w[32]" 0.11426466479975128;
	setAttr -s 6 ".wl[245].w";
	setAttr ".wl[245].w[0]" 0.086192363327417434;
	setAttr ".wl[245].w[1]" 0.10610790252747015;
	setAttr ".wl[245].w[7]" 0.3509614085378665;
	setAttr ".wl[245].w[8]" 0.01623444984231193;
	setAttr ".wl[245].w[13]" 0.35354632309710315;
	setAttr ".wl[245].w[32]" 0.086957552667830784;
	setAttr -s 8 ".wl[246].w";
	setAttr ".wl[246].w[0]" 0.075166486653170189;
	setAttr ".wl[246].w[1]" 2.5533242354460411e-005;
	setAttr ".wl[246].w[7]" 0.0036462253746560431;
	setAttr ".wl[246].w[13]" 0.84133801768840866;
	setAttr ".wl[246].w[14]" 0.026445407161234148;
	setAttr ".wl[246].w[19]" 0.037984212087282955;
	setAttr ".wl[246].w[25]" 0.015369040496676534;
	setAttr ".wl[246].w[32]" 2.5070660543825223e-005;
	setAttr -s 6 ".wl[247].w";
	setAttr ".wl[247].w[0]" 0.054466361564914523;
	setAttr ".wl[247].w[7]" 2.4084227971051855e-006;
	setAttr ".wl[247].w[13]" 0.84077292786738911;
	setAttr ".wl[247].w[14]" 0.028846472337076708;
	setAttr ".wl[247].w[19]" 0.063778425557959456;
	setAttr ".wl[247].w[25]" 0.012133377183300818;
	setAttr -s 8 ".wl[248].w";
	setAttr ".wl[248].w[0]" 0.056335880943950312;
	setAttr ".wl[248].w[1]" 0.0059470858550244032;
	setAttr ".wl[248].w[7]" 0.038063290078158105;
	setAttr ".wl[248].w[8]" 0.0099639059644559356;
	setAttr ".wl[248].w[13]" 0.84057401186220304;
	setAttr ".wl[248].w[14]" 0.023612298436650535;
	setAttr ".wl[248].w[19]" 0.02243157142245001;
	setAttr ".wl[248].w[25]" 0.0030719852394300862;
	setAttr -s 5 ".wl[249].w";
	setAttr ".wl[249].w[0]" 0.10241441134292328;
	setAttr ".wl[249].w[1]" 0.14453969904546587;
	setAttr ".wl[249].w[7]" 0.43993505543658784;
	setAttr ".wl[249].w[13]" 0.18400220513026327;
	setAttr ".wl[249].w[32]" 0.1291086290447597;
	setAttr -s 6 ".wl[250].w";
	setAttr ".wl[250].w[0]" 0.084051574031863377;
	setAttr ".wl[250].w[1]" 0.12928856932133093;
	setAttr ".wl[250].w[7]" 0.40261340182883337;
	setAttr ".wl[250].w[8]" 0.0074646907096079934;
	setAttr ".wl[250].w[13]" 0.26399729896183444;
	setAttr ".wl[250].w[32]" 0.11258446514652987;
	setAttr -s 5 ".wl[251].w";
	setAttr ".wl[251].w[0]" 0.067217720737547462;
	setAttr ".wl[251].w[1]" 0.23363100483125776;
	setAttr ".wl[251].w[7]" 0.39080375784950683;
	setAttr ".wl[251].w[13]" 0.14614872509628565;
	setAttr ".wl[251].w[32]" 0.16219880202098894;
	setAttr -s 6 ".wl[252].w";
	setAttr ".wl[252].w[0]" 0.045259545304881854;
	setAttr ".wl[252].w[7]" 5.2202090979939246e-005;
	setAttr ".wl[252].w[13]" 0.88760528821632556;
	setAttr ".wl[252].w[14]" 0.032633617302955595;
	setAttr ".wl[252].w[19]" 0.029790150450416896;
	setAttr ".wl[252].w[25]" 0.0046591940150955344;
	setAttr -s 5 ".wl[253].w";
	setAttr ".wl[253].w[0]" 0.078178827660430036;
	setAttr ".wl[253].w[1]" 0.14954656559459889;
	setAttr ".wl[253].w[7]" 0.45620451777894649;
	setAttr ".wl[253].w[13]" 0.18019228008338831;
	setAttr ".wl[253].w[32]" 0.13587783906330839;
	setAttr -s 39 ".pm";
	setAttr ".pm[0]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -2.0008258927344804 -0.66772283139307453 1.4952817023523011 1;
	setAttr ".pm[1]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -2.7341488723990164 -0.65266335404794096 1.5581053913616687 1;
	setAttr ".pm[2]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -2.9948229439762519 -0.70946594854429068 2.4479997260200443 1;
	setAttr ".pm[3]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -3.069585104711245 -1.3297722623272918 3.3745911924815766 1;
	setAttr ".pm[4]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -3.3686337476512174 -1.3940936688218537 4.5266122785648832 1;
	setAttr ".pm[5]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -3.3942880712990124 -0.68090838065752302 5.1854790798191983 1;
	setAttr ".pm[6]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -3.6897065039068639 -0.45871722486401545 6.2143019492265186 1;
	setAttr ".pm[7]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -2.4102118458167734 -0.67030290415734428 1.8643000050336827 1;
	setAttr ".pm[8]" -type "matrix" 1 -0 0 -0 -0 0.9908994417877407 -0.13460422082811474 0
		 0 0.13460422082811474 0.9908994417877407 -0 -2.3992872876054392 -0.37667968916027883 2.5118113606082737 1;
	setAttr ".pm[9]" -type "matrix" 0.89810206899679212 -6.2318349716483099e-018 -0.43978707764517277 -0
		 -3.1159174858241549e-018 1 1.5258179360446321e-018 0 0.43978707764517283 -3.0516358720892647e-018 0.89810206899679212 -0
		 -0.80473276651222259 -1.1032124875509526 3.869635670384739 1;
	setAttr ".pm[10]" -type "matrix" 1 -6.2318349716483099e-018 5.5511151231257827e-017 -0
		 -3.4694469519536142e-018 1 -1.9259299443872359e-034 0 1.0587488774892409e-035 -3.0516358720892647e-018 1 -0
		 -2.4178692965743984 -1.1833895691964682 4.2037783862941343 1;
	setAttr ".pm[11]" -type "matrix" 1 -6.2318349716483099e-018 5.5511151231257827e-017 -0
		 -3.4694469519536142e-018 1 -1.9259299443872359e-034 0 1.0587488774892409e-035 -3.0516358720892647e-018 1 -0
		 -2.4178692965743984 -0.49901969785393252 5.0397384362794337 1;
	setAttr ".pm[12]" -type "matrix" 1 -6.2318349716483099e-018 5.5511151231257827e-017 -0
		 -3.4694469519536142e-018 1 -1.9259299443872359e-034 0 1.0587488774892409e-035 -3.0516358720892647e-018 1 -0
		 -2.4355125575279444 -0.24238099610048103 6.1381073729231508 1;
	setAttr ".pm[13]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -1.6050012946018377 -0.70558200437615204 1.8551498851335131 1;
	setAttr ".pm[14]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -1.5529689897889716 -0.71288528264847462 2.4462145691075299 1;
	setAttr ".pm[15]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -1.5934836607468059 -1.097843335278651 3.1222119004051283 1;
	setAttr ".pm[16]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -1.5989464262400077 -1.183389569196468 4.2038336023190013 1;
	setAttr ".pm[17]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -1.5923043010169708 -0.49901969785393219 5.0392723847106895 1;
	setAttr ".pm[18]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -1.618546416755394 -0.24238099610048158 6.1365856884654839 1;
	setAttr ".pm[19]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -1.2664468582955579 -0.67030290415734495 1.5348956886275729 1;
	setAttr ".pm[20]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -1.0348582699005529 -0.70252680857187966 2.4406464399397159 1;
	setAttr ".pm[21]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -0.94436855853219193 -1.3304101437329969 3.3843248584954817 1;
	setAttr ".pm[22]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -0.63342797957852692 -1.3972715492975494 4.5185403983571559 1;
	setAttr ".pm[23]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -0.60826391630685128 -0.6763441651915707 5.1823915475982112 1;
	setAttr ".pm[24]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -0.32386768057771631 -0.44781469307446586 6.2089761149613913 1;
	setAttr ".pm[25]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -1.5135000956001403 -0.61738425382913364 1.1414405329202746 1;
	setAttr ".pm[26]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -1.0049140666299963 -0.94842497177875584 1.1233479680408935 1;
	setAttr ".pm[27]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -0.43745928214216967 -0.96501129263477203 1.1350645327279865 1;
	setAttr ".pm[28]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 0.43316300978297884 -1.0702649868126515 1.5280329744686663 1;
	setAttr ".pm[29]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 0.79579571302018515 -1.124663429090148 2.3894986504511491 1;
	setAttr ".pm[30]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 0.93179274984576876 -0.1805875173877558 3.2985298775901688 1;
	setAttr ".pm[31]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 0.92856846694577277 -0.13688935015665482 4.2857026871324333 1;
	setAttr ".pm[32]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -2.5017130448184708 -0.63502380393853697 1.1505906528204441 1;
	setAttr ".pm[33]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -3.0018495647014936 -0.93415602394380581 1.135823972969622 1;
	setAttr ".pm[34]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -3.5907182275357021 -1.0110584559787217 1.1702488406694975 1;
	setAttr ".pm[35]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -4.4447139010478027 -1.0943948423749539 1.5122421407656805 1;
	setAttr ".pm[36]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -4.807776564986618 -1.1401813481214891 2.4245534501503947 1;
	setAttr ".pm[37]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -4.9947107436373175 -0.19183373652270364 3.3050951577447201 1;
	setAttr ".pm[38]" -type "matrix" 1 -0 0 -0 -0 1 -0 0 0 -0 1 -0 -4.9199485829023253 -0.12788915768180287 4.2902849965363341 1;
	setAttr ".gm" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 2.0045052490946738 0.86382702011693047 -1.3685856195384933 1;
	setAttr -s 39 ".ma";
	setAttr -s 39 ".dpf[0:38]"  4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 
		4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4 4;
	setAttr -s 39 ".lw";
	setAttr -s 39 ".lw";
	setAttr ".mmi" yes;
	setAttr ".mi" 5;
	setAttr ".ucm" yes;
	setAttr -s 39 ".ifcl";
	setAttr -s 39 ".ifcl";
createNode objectSet -n "skinCluster1Set";
	rename -uid "C7A20C42-490D-1D78-0C8E-9BAA6081A286";
	setAttr ".ihi" 0;
	setAttr ".vo" yes;
createNode groupId -n "skinCluster1GroupId";
	rename -uid "E27C5003-41B6-C8DE-B677-8DBDE2FDE017";
	setAttr ".ihi" 0;
createNode groupParts -n "skinCluster1GroupParts";
	rename -uid "AACD241F-4F05-802F-A9D4-21A87B9DCDB4";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 1 "vtx[0:253]";
createNode dagPose -n "bindPose1";
	rename -uid "2C00AEE0-4AD1-53ED-6351-F78171CEE152";
	setAttr -s 40 ".wm";
	setAttr ".wm[0]" -type "matrix" 1 0 0 0 0 1 0 0 0 0 1 0 2.0045052490946738 0.86382702011693047 -1.3685856195384933 1;
	setAttr -s 40 ".xm";
	setAttr ".xm[0]" -type "matrix" "xform" 1 1 1 0 0 0 0 2.0045052490946738 0.86382702011693047
		 -1.3685856195384933 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[1]" -type "matrix" "xform" 1 1 1 0 0 0 0 -0.0036793563601933421
		 -0.19610418872385593 -0.12669608281380773 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 
		0 0 0 1 1 1 1 yes;
	setAttr ".xm[2]" -type "matrix" "xform" 1 1 1 0 0 0 0 0.73332297966453597 -0.015059477345133576
		 -0.062823689009367634 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[3]" -type "matrix" "xform" 1 1 1 0 0 0 0 0.26067407157723554 0.056802594496349723
		 -0.88989433465837564 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[4]" -type "matrix" "xform" 1 1 1 0 0 0 0 0.074762160734993088 0.62030631378300116
		 -0.92659146646153223 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[5]" -type "matrix" "xform" 1 1 1 0 0 0 0 0.29904864293997235 0.064321406494561861
		 -1.1520210860833067 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[6]" -type "matrix" "xform" 1 1 1 0 0 0 0 0.025654323647795074 -0.71318528816433069
		 -0.65886680125431507 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[7]" -type "matrix" "xform" 1 1 1 0 0 0 0 0.2954184326078515 -0.22219115579350757
		 -1.0288228694073203 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[8]" -type "matrix" "xform" 1 1 1 0 0 0 0 0.40938595308229297 0.0025800727642697474
		 -0.36901830268138158 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[9]" -type "matrix" "xform" 1 1 1 0.13501403755711044 0 0 0 -0.010924558211334201
		 0.041049200626239069 -0.5739497940079652 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1
		 1 1 yes;
	setAttr ".xm[10]" -type "matrix" "xform" 1 1 1 0 -0.45536157927792209 0 0 0.025260638018724357
		 0.29633708208330845 -0.72969579219536485 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 -0.067455756656712773 0 0 0.99772226641178574 1
		 1 1 yes;
	setAttr ".xm[11]" -type "matrix" "xform" 1 1 1 0 0 0 0 -0.48200676027117528
		 0.080177081645515624 -0.96913406801846325 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 
		0 0.22571877525275549 0 0.97419250381964861 1 1 1 yes;
	setAttr ".xm[12]" -type "matrix" "xform" 1 1 1 0 0 0 0 0 -0.68436987134253568
		 -0.83596004998529949 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[13]" -type "matrix" "xform" 1 1 1 0 0 0 0 0.017643260953545958
		 -0.25663870175345149 -1.098368936643717 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1
		 1 1 yes;
	setAttr ".xm[14]" -type "matrix" "xform" 1 1 1 0 0 0 0 -0.3958245981326427 0.037859172983077505
		 -0.35986818278121202 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[15]" -type "matrix" "xform" 1 1 1 0 0 0 0 -0.052032304812866137
		 0.0073032782723225775 -0.59106468397401679 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 
		0 0 0 1 1 1 1 yes;
	setAttr ".xm[16]" -type "matrix" "xform" 1 1 1 0 0 0 0 0.040514670957834342
		 0.38495805263017635 -0.67599733129759842 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1
		 1 1 yes;
	setAttr ".xm[17]" -type "matrix" "xform" 1 1 1 0 0 0 0 0.0054627654932017933
		 0.085546233917817016 -1.081621701913873 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1
		 1 1 yes;
	setAttr ".xm[18]" -type "matrix" "xform" 1 1 1 0 0 0 0 -0.0066421252230368655
		 -0.6843698713425358 -0.83543878239168823 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1
		 1 1 yes;
	setAttr ".xm[19]" -type "matrix" "xform" 1 1 1 0 0 0 0 0.026242115738423166
		 -0.2566387017534506 -1.0973133037547944 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1
		 1 1 yes;
	setAttr ".xm[20]" -type "matrix" "xform" 1 1 1 0 0 0 0 -0.7343790344389225 0.0025800727642704135
		 -0.039613986275271795 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[21]" -type "matrix" "xform" 1 1 1 0 0 0 0 -0.23158858839500507
		 0.03222390441453471 -0.905750751312143 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1
		 1 1 yes;
	setAttr ".xm[22]" -type "matrix" "xform" 1 1 1 0 0 0 0 -0.090489711368360926
		 0.62788333516111727 -0.94367841855576584 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1
		 1 1 yes;
	setAttr ".xm[23]" -type "matrix" "xform" 1 1 1 0 0 0 0 -0.310940578953665 0.066861405564552445
		 -1.1342155398616742 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[24]" -type "matrix" "xform" 1 1 1 0 0 0 0 -0.025164063271675641
		 -0.72092738410597867 -0.66385114924105526 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 
		0 0 0 1 1 1 1 yes;
	setAttr ".xm[25]" -type "matrix" "xform" 1 1 1 0 0 0 0 -0.28439623572913497
		 -0.22852947211710484 -1.0265845673631802 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1
		 1 1 yes;
	setAttr ".xm[26]" -type "matrix" "xform" 1 1 1 0 0 0 0 -0.4873257971343401 -0.050338577563940889
		 0.35384116943202648 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[27]" -type "matrix" "xform" 1 1 1 0 0 0 0 -0.50858602897014404
		 0.3310407179496222 0.018092564879381046 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1
		 1 1 yes;
	setAttr ".xm[28]" -type "matrix" "xform" 1 1 1 0 0 0 0 -0.5674547844878266 0.01658632085601619
		 -0.011716564687092923 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[29]" -type "matrix" "xform" 1 1 1 0 0 0 0 -0.87062229192514851
		 0.10525369417787944 -0.3929684417406798 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1
		 1 1 yes;
	setAttr ".xm[30]" -type "matrix" "xform" 1 1 1 0 0 0 0 -0.36263270323720631
		 0.054398442277496573 -0.8614656759824828 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1
		 1 1 yes;
	setAttr ".xm[31]" -type "matrix" "xform" 1 1 1 0 0 0 0 -0.13599703682558362
		 -0.94407591170239225 -0.90903122713901974 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 
		0 0 0 1 1 1 1 yes;
	setAttr ".xm[32]" -type "matrix" "xform" 1 1 1 0 0 0 0 0.0032242828999959894
		 -0.043698167231100982 -0.9871728095422645 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 
		0 0 0 1 1 1 1 yes;
	setAttr ".xm[33]" -type "matrix" "xform" 1 1 1 0 0 0 0 0.50088715208399037 -0.032699027454537566
		 0.34469104953185692 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[34]" -type "matrix" "xform" 1 1 1 0 0 0 0 0.50013651988302277 0.29913222000526885
		 0.01476667985082214 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[35]" -type "matrix" "xform" 1 1 1 0 0 0 0 0.58886866283420858 0.076902432034915869
		 -0.034424867699875517 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[36]" -type "matrix" "xform" 1 1 1 0 0 0 0 0.85399567351210059 0.083336386396232198
		 -0.34199330009618301 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[37]" -type "matrix" "xform" 1 1 1 0 0 0 0 0.36306266393881526 0.0457865057465352
		 -0.91231130938471416 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[38]" -type "matrix" "xform" 1 1 1 0 0 0 0 0.1869341786506995 -0.94834761159878544
		 -0.88054170759432537 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr ".xm[39]" -type "matrix" "xform" 1 1 1 0 0 0 0 -0.0747621607349922 -0.063944578840900768
		 -0.98518983879161404 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 1 0 0 0 1 1 1 1 yes;
	setAttr -s 40 ".m";
	setAttr -s 40 ".p";
	setAttr -s 40 ".g[0:39]" yes no no no no no no no no no no no no no 
		no no no no no no no no no no no no no no no no no no no no no no no no no no;
	setAttr ".bp" yes;
createNode animCurveTU -n "kraken_visibility";
	rename -uid "D49A4E00-4636-1A66-60CD-369108B09A58";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 2 ".ktv[0:1]"  1 1 5 1;
	setAttr -s 2 ".kot[0:1]"  5 5;
createNode animCurveTL -n "joint32_translateX";
	rename -uid "8EA0F392-48F6-6AAB-D354-6F807E657EB5";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -0.029476771979328298 5 -0.029476771979328298
		 10 -0.029476771979328298 12 -0.029476771979328298 14 -0.029476771979328298 16 -0.029476771979328183
		 20 -0.029476771979327677 25 -0.029476771979326966 30 -0.029476771979326966 35 -0.029476771979327854;
createNode animCurveTL -n "joint32_translateY";
	rename -uid "FDA03ED3-49E3-348F-789D-58827255D059";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -0.25625709289959175 5 -0.25625709289959175
		 10 -0.25625709289959175 12 0.0015234943646784214 14 0.48981941999360262 16 0.47063719741389987
		 20 0.77381502853367767 25 0.26972016548336342 30 0.26972016548336342 35 -0.24573659087297189;
createNode animCurveTL -n "joint32_translateZ";
	rename -uid "BFEA5126-4422-BEE6-8DAD-AA8D2E7DCC22";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -1.3403395616803193 5 -1.3403395616803193
		 10 -1.3403395616803193 12 -0.89089679888994444 14 -0.80382674589575176 16 -0.81956699132923683
		 20 -0.50568944380140202 25 -0.98443231812928744 30 -0.98443231812928744 35 -1.0827377338298643;
createNode animCurveTU -n "joint32_visibility";
	rename -uid "0843810B-46F0-2377-B881-788D3ACA48A2";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 1 30 1
		 35 1;
	setAttr -s 10 ".kot[0:9]"  5 5 5 5 5 5 5 5 
		5 5;
createNode animCurveTA -n "joint32_rotateX";
	rename -uid "161788C5-43A4-81ED-BA52-5AB441EF53B4";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 23.898314048414623 14 47.796615276777224
		 16 43.631015920997001 20 43.087597572665466 25 0 30 0 35 0;
createNode animCurveTA -n "joint32_rotateY";
	rename -uid "98E366A5-4D8D-1A46-D8DB-11BC1D250EBF";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0;
createNode animCurveTA -n "joint32_rotateZ";
	rename -uid "9437D27E-459F-177C-5DB0-01934D9BD07E";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0;
createNode animCurveTU -n "joint32_scaleX";
	rename -uid "75635E02-4F82-0F37-1A37-1DBA3543A2CA";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1;
createNode animCurveTU -n "joint32_scaleY";
	rename -uid "AE2BB18C-4CC0-ADF8-D9AB-0BBDB13F2896";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1;
createNode animCurveTU -n "joint32_scaleZ";
	rename -uid "3D5C475B-43A8-E5A2-6B55-6B805B1CBEF5";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1;
createNode animCurveTL -n "back_left_translateX";
	rename -uid "ABEDA1D7-4034-568F-65EF-7CA5CE33ABE3";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.4873257971343401 5 -0.4873257971343401
		 10 -0.4873257971343401 12 -0.4873257971343401 14 -0.4873257971343401 16 -0.4873257971343401
		 20 -0.4873257971343401 25 -0.4873257971343401 30 -0.4873257971343401 35 -0.4873257971343401
		 40 -0.4873257971343401;
createNode animCurveTL -n "back_left_translateY";
	rename -uid "A131D828-4AD9-D4A2-776B-CCB6252513F1";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.050338577563940889 5 -0.050338577563940889
		 10 -0.050338577563940889 12 -0.050338577563940889 14 -0.050338577563940889 16 -0.050338577563940889
		 20 -0.050338577563940889 25 -0.050338577563940889 30 -0.050338577563940889 35 -0.050338577563940889
		 40 -0.050338577563940889;
createNode animCurveTL -n "back_left_translateZ";
	rename -uid "4B9BBAE2-4429-4BEB-60FC-80B2777F27DB";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.35384116943202648 5 0.35384116943202648
		 10 0.35384116943202648 12 0.35384116943202648 14 0.35384116943202648 16 0.35384116943202648
		 20 0.35384116943202648 25 0.35384116943202648 30 0.35384116943202648 35 0.35384116943202648
		 40 0.35384116943202648;
createNode animCurveTL -n "joint16_translateX";
	rename -uid "A6FDA7FC-46E0-F1EF-6DD6-3EA7AA32E6D6";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.50858602897014404 5 -0.50858602897014404
		 10 -0.50858602897014404 12 -0.50858602897014404 14 -0.50858602897014404 16 -0.50858602897014404
		 20 -0.50858602897014404 25 -0.50858602897014404 30 -0.50858602897014404 35 -0.50858602897014404
		 40 -0.50858602897014404;
createNode animCurveTL -n "joint16_translateY";
	rename -uid "0105F911-46BD-9CB2-5709-929A78B2CEB7";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.3310407179496222 5 0.3310407179496222
		 10 0.3310407179496222 12 0.3310407179496222 14 0.3310407179496222 16 0.3310407179496222
		 20 0.3310407179496222 25 0.3310407179496222 30 0.3310407179496222 35 0.3310407179496222
		 40 0.3310407179496222;
createNode animCurveTL -n "joint16_translateZ";
	rename -uid "344DDDBF-4A33-29A7-283E-4EA855562383";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.018092564879381046 5 0.018092564879381046
		 10 0.018092564879381046 12 0.018092564879381046 14 0.018092564879381046 16 0.018092564879381046
		 20 0.018092564879381046 25 0.018092564879381046 30 0.018092564879381046 35 0.018092564879381046
		 40 0.018092564879381046;
createNode animCurveTL -n "joint17_translateX";
	rename -uid "8353B284-41D7-B001-E1D0-E2A2409F8466";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.5674547844878266 5 -0.5674547844878266
		 10 -0.5674547844878266 12 -0.5674547844878266 14 -0.5674547844878266 16 -0.5674547844878266
		 20 -0.5674547844878266 25 -0.5674547844878266 30 -0.5674547844878266 35 -0.5674547844878266
		 40 -0.5674547844878266;
createNode animCurveTL -n "joint17_translateY";
	rename -uid "49065AFA-4462-0B6E-C616-13B1878AE333";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.01658632085601619 5 0.01658632085601619
		 10 0.01658632085601619 12 0.16982757144702931 14 0.01658632085601619 16 0.01658632085601619
		 20 0.01658632085601619 25 0.01658632085601619 30 0.01658632085601619 35 0.01658632085601619
		 40 0.01658632085601619;
createNode animCurveTL -n "joint17_translateZ";
	rename -uid "4F5DA447-41CC-8D57-C138-CC8CA2ED1472";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.011716564687092923 5 -0.011716564687092923
		 10 -0.011716564687092923 12 -0.011716564687092923 14 -0.011716564687092923 16 -0.011716564687092923
		 20 -0.011716564687092923 25 -0.011716564687092923 30 -0.011716564687092923 35 -0.011716564687092923
		 40 -0.011716564687092923;
createNode animCurveTL -n "joint18_translateX";
	rename -uid "50F5036E-4849-CD2B-F69F-71AC3C949143";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.87062229192514851 5 -0.73342905817086934
		 10 -0.87062229192514851 12 -0.87062229192514839 14 -0.87062229192514851 16 -0.87062229192514851
		 20 -0.87062229192514851 25 -0.87062229192514851 30 -0.87062229192514851 35 -0.87062229192514851
		 40 -0.87062229192514851;
createNode animCurveTL -n "joint18_translateY";
	rename -uid "963CE906-4695-51EA-AA5F-8E940E828B82";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.10525369417787944 5 -0.12687936415367715
		 10 0.10525369417787944 12 0.31163191687299974 14 0.10525369417787944 16 0.10525369417787944
		 20 0.10525369417787944 25 0.10525369417787944 30 0.10525369417787944 35 0.10525369417787944
		 40 0.10525369417787944;
createNode animCurveTL -n "joint18_translateZ";
	rename -uid "49955B7B-4242-6242-C537-EC88AA2397B2";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.3929684417406798 5 -0.3929684417406798
		 10 -0.3929684417406798 12 -0.3929684417406798 14 -0.3929684417406798 16 -0.3929684417406798
		 20 -0.3929684417406798 25 -0.3929684417406798 30 -0.3929684417406798 35 -0.3929684417406798
		 40 -0.3929684417406798;
createNode animCurveTL -n "joint19_translateX";
	rename -uid "32A4AEDF-468A-339D-6744-CCAC71386F99";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.36263270323720631 5 -0.36263270323720631
		 10 -0.36263270323720631 12 -0.36263270323720631 14 -0.36263270323720631 16 -0.36263270323720631
		 20 -0.36263270323720631 25 -0.36263270323720631 30 -0.36263270323720631 35 -0.36263270323720631
		 40 -0.36263270323720631;
createNode animCurveTL -n "joint19_translateY";
	rename -uid "AE35433A-4CCB-58CE-F7ED-2BAD9331DEA9";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.054398442277496573 5 0.054398442277496573
		 10 0.054398442277496573 12 0.54857949037052955 14 0.054398442277496573 16 0.054398442277496573
		 20 0.054398442277496573 25 -0.055726203981359801 30 0.40092863697767361 35 0.044606448270746182
		 40 -0.12185168494959411;
createNode animCurveTL -n "joint19_translateZ";
	rename -uid "1E490C4F-460A-27FB-32B0-B7A1B04E89C4";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.8614656759824828 5 -0.8614656759824828
		 10 -0.8614656759824828 12 -0.79070310728298288 14 -0.8614656759824828 16 -0.8614656759824828
		 20 -0.8614656759824828 25 -0.89366369559307801 30 -0.76014788397438959 35 -0.86432863923155567
		 40 -0.91299732893770347;
createNode animCurveTL -n "joint20_translateX";
	rename -uid "97DB5511-449C-A3B3-07F4-31BA557C272F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.13599703682558362 5 -0.13599703682558362
		 10 -0.13599703682558362 12 -0.13599703682558373 14 -0.13599703682558362 16 -0.13599703682558362
		 20 -0.13599703682558362 25 -0.13599703682558362 30 -0.13599703682558373 35 -0.13599703682558373
		 40 -0.13599703682558373;
createNode animCurveTL -n "joint20_translateY";
	rename -uid "A0B7CB9A-493C-E2A6-9FE7-BBBA2ABF8F31";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.94407591170239225 5 -0.94407591170239225
		 10 -0.94407591170239225 12 0.60438309503824539 14 -0.16081034848373138 16 -0.16081034848373138
		 20 0.15560473951315282 25 -0.039109667007588819 30 0.51847483009160811 35 -0.032310598354990436
		 40 -0.095620792568442678;
createNode animCurveTL -n "joint20_translateZ";
	rename -uid "54EB0304-4F5D-04BC-CA3C-639914139F8C";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.90903122713901974 5 -0.90903122713901974
		 10 -0.90903122713901974 12 -0.62887863360102836 14 -0.68002163826335849 16 -0.68002163826335849
		 20 -0.68815692662607042 25 -0.76776892165238808 30 -0.53979188080058826 35 -0.76498901733289637
		 40 -0.79087436889418239;
createNode animCurveTL -n "joint21_translateX";
	rename -uid "E8AFFADA-411E-4559-0FF5-DA9C787C1D43";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.0032242828999959894 5 0.0032242828999959894
		 10 0.0032242828999959894 12 0.0032242828999962114 14 0.0032242828999959894 16 0.0032242828999959894
		 20 0.0032242828999959894 25 0.0032242828999959894 30 0.0032242828999959894 35 0.0032242828999959894
		 40 0.0032242828999959894;
createNode animCurveTL -n "joint21_translateY";
	rename -uid "E3BD8F72-48EA-B574-E846-35A5A919F1FA";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.043698167231100982 5 -0.043698167231100982
		 10 -0.043698167231100982 12 -0.093484311710545803 14 -0.043698167231100982 16 -0.043698167231100982
		 20 -0.043698167231100982 25 0.067656344501734786 30 0.30346252111709826 35 0.30346252111709826
		 40 -0.05098393226797529;
createNode animCurveTL -n "joint21_translateZ";
	rename -uid "FF5154C0-461F-11EE-8BEA-E7BCBB92CD9D";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.9871728095422645 5 -0.9871728095422645
		 10 -0.9871728095422645 12 -0.73913197386186891 14 -0.9871728095422645 16 -0.9871728095422645
		 20 -0.9871728095422645 25 -0.95816791490139097 30 -0.82546785408393675 35 -0.82546785408393675
		 40 -0.91779174717352263;
createNode animCurveTL -n "back_right_translateX";
	rename -uid "48D65356-4AFD-F191-D91E-CB95A21A3E25";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.50088715208399037 5 0.50088715208399037
		 10 0.50088715208399037 12 0.50088715208399037 14 0.50088715208399037 16 0.50088715208399037
		 20 0.50088715208399037 25 0.50088715208399037 30 0.50088715208399037 35 0.50088715208399037
		 40 0.50088715208399037;
createNode animCurveTL -n "back_right_translateY";
	rename -uid "020178DD-4E22-66A4-845F-308C1D080FD1";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.032699027454537566 5 -0.032699027454537566
		 10 -0.032699027454537566 12 -0.032699027454537566 14 -0.032699027454537566 16 -0.032699027454537566
		 20 -0.032699027454537566 25 -0.032699027454537566 30 -0.032699027454537566 35 -0.032699027454537566
		 40 -0.032699027454537566;
createNode animCurveTL -n "back_right_translateZ";
	rename -uid "7E33DB0A-47A7-DF66-2415-B899D0FEF7EC";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.34469104953185692 5 0.34469104953185692
		 10 0.34469104953185692 12 0.34469104953185692 14 0.34469104953185692 16 0.34469104953185692
		 20 0.34469104953185692 25 0.34469104953185692 30 0.34469104953185692 35 0.34469104953185692
		 40 0.34469104953185692;
createNode animCurveTL -n "joint22_translateX";
	rename -uid "0C6693BB-41AA-788D-4BEF-FCBE95B679ED";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.22754357435461126 5 0.3412174487932515
		 10 0.50013651988302277 12 0.50013651988302277 14 0.50013651988302277 16 0.50013651988302277
		 20 0.50013651988302277 25 0.50013651988302277 30 0.50013651988302277 35 0.50013651988302277
		 40 0.50013651988302277;
createNode animCurveTL -n "joint22_translateY";
	rename -uid "6C0D8798-4CBF-CB61-CE0A-4289270B31ED";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.033134261420622479 5 0.14405796300971663
		 10 0.29913222000526885 12 0.29913222000526885 14 0.29913222000526885 16 0.29913222000526885
		 20 0.29913222000526885 25 0.29913222000526885 30 0.29913222000526885 35 0.29913222000526885
		 40 0.29913222000526885;
createNode animCurveTL -n "joint22_translateZ";
	rename -uid "B3F71919-4977-86C9-6E02-239303A9D321";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.01476667985082214 5 0.01476667985082214
		 10 0.01476667985082214 12 0.01476667985082214 14 0.01476667985082214 16 0.01476667985082214
		 20 0.01476667985082214 25 0.01476667985082214 30 0.01476667985082214 35 0.01476667985082214
		 40 0.01476667985082214;
createNode animCurveTL -n "joint23_translateX";
	rename -uid "730286E8-4FFC-F335-1AA6-6399AA9CF3A7";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.58886866283420858 5 0.49249001262389996
		 10 0.58886866283420858 12 0.58886866283420858 14 0.58886866283420858 16 0.58886866283420858
		 20 0.58886866283420858 25 0.58886866283420858 30 0.58886866283420858 35 0.58886866283420858
		 40 0.58886866283420858;
createNode animCurveTL -n "joint23_translateY";
	rename -uid "AF37623A-4FC5-DAC4-5E07-26B7FDA23B08";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.076902432034915869 5 0.37088899366700129
		 10 0.23626334023853673 12 0.25147804801546436 14 0.076902432034915869 16 0.076902432034915869
		 20 0.076902432034915869 25 0.076902432034915869 30 0.076902432034915869 35 0.076902432034915869
		 40 0.076902432034915869;
createNode animCurveTL -n "joint23_translateZ";
	rename -uid "8F5E5A7E-412A-DC53-79C7-37928A6E8813";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.034424867699875517 5 -0.034424867699875517
		 10 -0.034424867699875517 12 -0.034424867699875517 14 -0.034424867699875517 16 -0.034424867699875517
		 20 -0.034424867699875517 25 -0.034424867699875517 30 -0.034424867699875517 35 -0.034424867699875517
		 40 -0.034424867699875517;
createNode animCurveTL -n "joint24_translateX";
	rename -uid "76580D97-4CA2-F196-C161-C4ABD0228BD5";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.85399567351210059 5 1.5423239196456413
		 10 0.85399567351210059 12 0.93525603979629335 14 0.85399567351210059 16 0.85399567351210059
		 20 0.85399567351210059 25 0.85399567351210059 30 0.85399567351210059 35 0.85399567351210059
		 40 0.85399567351210059;
createNode animCurveTL -n "joint24_translateY";
	rename -uid "FFBE6B39-442F-CD7D-5B47-628298FFF1AE";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.083336386396232198 5 -0.77807559818948313
		 10 0.083336386396232198 12 -0.45680620637664682 14 0.083336386396232198 16 0.083336386396232198
		 20 0.083336386396232198 25 0.083336386396232198 30 0.083336386396232198 35 -0.19564586908697246
		 40 0.083336386396232198;
createNode animCurveTL -n "joint24_translateZ";
	rename -uid "43655517-46C8-3CAC-9D59-27A36D24BCB1";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.34199330009618301 5 -0.34199330009618323
		 10 -0.34199330009618301 12 -0.34199330009618278 14 -0.34199330009618301 16 -0.34199330009618301
		 20 -0.34199330009618301 25 -0.34199330009618301 30 -0.34199330009618301 35 -0.34199330009618301
		 40 -0.34199330009618301;
createNode animCurveTL -n "joint25_translateX";
	rename -uid "A757C176-4132-439A-DE55-2E84F587439E";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.36306266393881526 5 0.36120400355936166
		 10 0.3572297536672695 12 0.39444364845388452 14 0.36306266393881526 16 0.36306266393881526
		 20 0.36306266393881526 25 0.36306266393881526 30 0.36306266393881526 35 0.36306266393881526
		 40 0.36306266393881526;
createNode animCurveTL -n "joint25_translateY";
	rename -uid "E71F45D4-4BCA-F2CE-EFC5-CA88658B52C0";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.50909164178747934 5 0.50909164178747934
		 10 0.50909164178747934 12 0.25775323279803036 14 0.50909164178747934 16 0.50909164178747934
		 20 0.84177114756738214 25 -0.091217579366626111 30 -0.091217579366626111 35 0.14360319896771867
		 40 -0.24234029189672102;
createNode animCurveTL -n "joint25_translateZ";
	rename -uid "74162386-4F29-7DBA-1360-60AFDC5FFEEF";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.91231130938471416 5 -0.87251884781795774
		 10 -0.78743327672120245 12 -0.77374653191763199 14 -0.6821749611240091 16 -0.6821749611240091
		 20 -0.6821749611240091 25 -0.6821749611240091 30 -0.6821749611240091 35 -0.6821749611240091
		 40 -0.6821749611240091;
createNode animCurveTL -n "joint26_translateX";
	rename -uid "7466CCA4-41A1-E0E4-E6BA-1C80FC916BAA";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.1869341786506995 5 0.1869341786506995
		 10 0.1869341786506995 12 0.1869341786506995 14 0.1869341786506995 16 0.1869341786506995
		 20 0.032153256658786204 25 -0.28957063401891026 30 0.032355519703094138 35 -0.27563400213126876
		 40 -0.1229272938535144;
createNode animCurveTL -n "joint26_translateY";
	rename -uid "FF0EC666-4E86-0934-7D54-F2BF7E0147FF";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.55008545762133143 5 0.55008545762133143
		 10 0.55008545762133143 12 0.55008545762133143 14 0.55008545762133143 16 0.89112179419294169
		 20 0.57577326803906492 25 -0.079702571283066598 30 0.57618535598954679 35 -0.051308268750446251
		 40 0.2598142828500391;
createNode animCurveTL -n "joint26_translateZ";
	rename -uid "83CBD09B-4C13-9334-00EC-D480255C376F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.88054170759432537 5 -0.88054170759432537
		 10 -0.88054170759432537 12 -0.88054170759432537 14 -0.88054170759432537 16 -0.37787181447499313
		 20 -0.47260390408909381 25 -0.66951174034212557 30 -0.47248011104927934 35 -0.66098196649204199
		 40 -0.56751937829271282;
createNode animCurveTL -n "joint27_translateX";
	rename -uid "21AC2A99-40C5-4901-C67B-988FDBF0B4EA";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.0747621607349922 5 -0.074548822720892013
		 10 -0.074092656261384324 12 -0.0740287364768141 14 -0.0747621607349922 16 -0.0747621607349922
		 20 -0.33203443602336585 25 -0.22894757847205516 30 -0.30781842062520587 35 -0.38523028884949856
		 40 -0.47784843808010824;
createNode animCurveTL -n "joint27_translateY";
	rename -uid "7F1209B4-4D38-B063-159E-6586041EF718";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0.23404315769724393 5 0.24994353509431466
		 10 0.28394225358115821 12 0.28870628367338502 14 0.23404315769724393 16 0.23404315769724393
		 20 -0.31022158510381542 25 -0.092139236555203591 30 -0.25899211089182406 35 -0.42275849614114142
		 40 -0.55639161800716641;
createNode animCurveTL -n "joint27_translateZ";
	rename -uid "D6F661BF-4EA4-AAF6-AEBA-45A996280613";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -0.98518983879161404 5 -0.9570780021886095
		 10 -0.89696833378845575 12 -0.88854553780044121 14 -0.98518983879161404 16 -0.98518983879161404
		 20 -0.92759928412957404 25 -0.95067533963571904 30 -0.93302005384493247 35 -0.91569136025187126
		 40 -1.1156878393411613;
createNode animCurveTL -n "front_left_translateX";
	rename -uid "7AF0858A-4F11-2402-7E4B-C0A1BD9071D6";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -0.3958245981326427 5 -0.3958245981326427
		 8 -0.3958245981326427 10 -0.3958245981326427 12 -0.3958245981326427 14 -0.3958245981326427
		 15 -0.3958245981326427 16 -0.3958245981326427 20 -0.3958245981326427 25 -0.3958245981326427
		 30 -0.3958245981326427 35 -0.3958245981326427;
createNode animCurveTL -n "front_left_translateY";
	rename -uid "5424EA99-4DF1-C186-B1F3-789550D5DD29";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0.037859172983077505 5 0.037859172983077505
		 8 0.037859172983077505 10 0.037859172983077505 12 0.037859172983077505 14 0.037859172983077505
		 15 0.037859172983077505 16 0.037859172983077505 20 0.037859172983077505 25 0.037859172983077505
		 30 0.037859172983077505 35 0.037859172983077505;
createNode animCurveTL -n "front_left_translateZ";
	rename -uid "78DC37FF-4278-07A3-CD99-D3A4ADBE8304";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -0.35986818278121202 5 -0.35986818278121202
		 8 -0.35986818278121202 10 -0.35986818278121202 12 -0.35986818278121202 14 -0.35986818278121202
		 15 -0.35986818278121202 16 -0.35986818278121202 20 -0.35986818278121202 25 -0.35986818278121202
		 30 -0.35986818278121202 35 -0.35986818278121202;
createNode animCurveTL -n "joint6_translateX";
	rename -uid "B5D18D12-444B-D87E-FF04-73AE8A1DA4BA";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -0.052032304812866137 5 0.1600824769467219
		 8 0.29775316104560612 10 0.20706805879978618 12 0.048369054466854466 14 -0.052032304812866137
		 15 -0.052032304812866137 16 -0.052032304812866137 20 -0.052032304812866137 25 -0.052032304812866137
		 30 -0.052032304812866137 35 -0.052032304812866137;
createNode animCurveTL -n "joint6_translateY";
	rename -uid "5FC69518-4E16-C482-C308-8ABF8B651BD4";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0.0073032782723225775 5 0.0073032782723226452
		 8 0.0073032782723226886 10 0.0073032782723226599 12 0.53754648573312092 14 0.0073032782723225775
		 15 0.0073032782723225775 16 0.0073032782723225775 20 0.0073032782723225775 25 0.0073032782723225775
		 30 0.0073032782723225775 35 0.0073032782723225775;
createNode animCurveTL -n "joint6_translateZ";
	rename -uid "44C5C5C5-497B-1566-4C1C-83A385ACF467";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -0.59106468397401679 5 -0.59106468397401679
		 8 -0.59106468397401679 10 -0.59106468397401679 12 -0.59106468397401679 14 -0.59106468397401679
		 15 -0.59106468397401679 16 -0.59106468397401679 20 -0.59106468397401679 25 -0.59106468397401679
		 30 -0.59106468397401679 35 -0.59106468397401679;
createNode animCurveTL -n "joint7_translateX";
	rename -uid "6C1CBEE9-4A21-1645-4952-E0A8E0913C4F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0.040514670957834342 5 0.040514670957834342
		 8 0.040514670957834342 10 0.040514670957834342 12 0.040514670957834342 14 0.040514670957834342
		 15 0.04051467095783412 16 0.040514670957834342 20 0.040514670957834342 25 0.040514670957834342
		 30 0.040514670957834342 35 0.04051467095783412;
createNode animCurveTL -n "joint7_translateY";
	rename -uid "A4C2D21A-4B81-BD6B-E597-EDA8C2B91510";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0.38495805263017635 5 0.38495805263017635
		 8 0.38495805263017635 10 0.38495805263017635 12 0.38495805263017635 14 0.38495805263017635
		 15 0.18403769458573102 16 0.38495805263017635 20 0.38495805263017635 25 0.38495805263017635
		 30 0.38495805263017635 35 0.069186792268506908;
createNode animCurveTL -n "joint7_translateZ";
	rename -uid "BC391F00-457F-BC96-6C3B-A594EB39846F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -0.67599733129759842 5 -0.67599733129759842
		 8 -0.67599733129759842 10 -0.67599733129759842 12 -0.67599733129759842 14 -0.67599733129759842
		 15 -0.62262062219360736 16 -0.67599733129759842 20 -0.67599733129759842 25 -0.67599733129759842
		 30 -0.67599733129759842 35 -0.59210921328022437;
createNode animCurveTL -n "joint8_translateX";
	rename -uid "9B3B21D1-4101-CB17-4ACE-94A466C3D6CE";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0.0054627654932017933 5 0.0054627654932026815
		 8 0.0054627654932017933 10 0.0054627654932017933 12 0.0054627654932009051 14 0.0054627654932017933
		 15 0.0054627654932016823 16 0.0054627654932013492 20 0.0054627654932011271 25 0.0054627654932011271
		 30 0.0054627654932009051 35 0.005462765493200461;
createNode animCurveTL -n "joint8_translateY";
	rename -uid "E33F9ED8-4298-75CF-D133-928339A34FA9";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0.085546233917817016 5 0.35493414705606208
		 8 0.085546233917817016 10 0.085546233917817016 12 0.85298049630924166 14 0.085546233917817016
		 15 -0.36504086306357819 16 -0.39691855887400557 20 0.23481110717998888 25 0.23481110717998888
		 30 -0.19193051372856218 35 -0.49877232854700432;
createNode animCurveTL -n "joint8_translateZ";
	rename -uid "02434DEA-4CE5-962F-A04B-2C8101C2C355";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -1.081621701913873 5 -0.72427340694834452
		 8 -1.081621701913873 10 -1.081621701913873 12 -1.0814946228754769 14 -1.081621701913873
		 15 -0.96196592465951158 16 -0.95344960851122018 20 -1.1212755617671206 25 -1.1212755617671206
		 30 -0.86058006690967948 35 -0.67313109348462863;
createNode animCurveTL -n "joint9_translateX";
	rename -uid "B5155FB5-42F9-CA23-8EC0-48B6099E7E44";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -0.0066421252230368655 5 -0.0066421252230368655
		 8 -0.0066421252230368655 10 -0.0066421252230368655 12 -0.0066421252230364214 14 -0.0066421252230364214
		 15 -0.039145259548730271 16 -0.0066421252230357553 20 -0.0069201564943185247 25 -0.030538182554628888
		 30 -0.004944320254767905 35 -0.0095008804933241729;
createNode animCurveTL -n "joint9_translateY";
	rename -uid "3A7B534B-4992-CDF4-8434-CBABF20D743B";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -0.6843698713425358 5 -0.45861840758712208
		 8 -0.3120969902973183 10 -0.40861216195568301 12 0.065389461066651056 14 -0.081137857367772154
		 15 -0.89497999389506822 16 -0.52346691673337142 20 -0.44260456393059322 25 -0.13677108862938051
		 30 -0.42341336286232506 35 -0.37238148755734812;
createNode animCurveTL -n "joint9_translateZ";
	rename -uid "A40B57E7-4537-A7AB-47DE-21B4EC308C80";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -0.83543878239168823 5 -0.95945181647431677
		 8 -1.0399410643131792 10 -0.98692196502030705 12 -0.84242971635692232 14 -0.99569402006662411
		 15 -0.92342498557168573 16 -0.73106343378348237 20 -0.55970838846144488 25 -0.70406936062907255
		 30 -0.44733913893740218 35 -0.49304567226521501;
createNode animCurveTL -n "joint10_translateX";
	rename -uid "81D9A0AC-4170-529F-909E-968FCF1288A1";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0.026242115738423166 5 0.026242115738423031
		 8 0.026242115738422944 10 0.026242115738423003 12 0.026242115738423086 14 0.026242115738423166
		 15 0.026242115738423166 16 0.026242115738422944 20 0.026028373179357096 25 0.020129374359094152
		 30 0.0040146558519660556 35 0.041383180169505471;
createNode animCurveTL -n "joint10_translateY";
	rename -uid "8D8BA854-48E3-32FB-997F-B28B07E5BC71";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -0.2566387017534506 5 -0.68166183331122188
		 8 -0.95751825780938638 10 -0.77580878041030443 12 -0.54411127103307844 14 -0.2566387017534506
		 15 0.37260883113859639 16 -0.33695857391433265 20 -0.34952801611945145 25 -0.26537306664728411
		 30 0.010239701603811682 35 -0.54004964185756321;
createNode animCurveTL -n "joint10_translateZ";
	rename -uid "7A16CDC6-4B12-6B04-09D2-829392848465";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -1.0973133037547944 5 -0.86383349714372704
		 8 -0.7122960869133913 10 -0.81211534495480708 12 -0.58286768525631871 14 -1.0973133037547944
		 15 -0.83009505495659175 16 -0.80442110183845228 20 -0.65930041319361288 25 -0.65202012864957404
		 30 -1.0561722807128018 35 -0.94285106806078278;
createNode animCurveTL -n "front_right_translateX";
	rename -uid "6B759D37-4F25-C823-CE5C-21B79ED66D6E";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0.40938595308229297 5 0.40938595308229297
		 10 0.40938595308229297 12 0.40938595308229297 14 0.40938595308229297 16 0.40938595308229297
		 20 0.40938595308229297 25 0.40938595308229297 30 0.40938595308229297 35 0.40938595308229297
		 40 0.40938595308229297 45 0.40938595308229297;
createNode animCurveTL -n "front_right_translateY";
	rename -uid "D881111B-4873-6D6A-CF08-B492CD3C8606";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0.0025800727642697474 5 0.0025800727642697474
		 10 0.0025800727642697474 12 0.0025800727642697474 14 0.0025800727642697474 16 0.0025800727642697474
		 20 0.0025800727642697474 25 0.0025800727642697474 30 0.0025800727642697474 35 0.0025800727642697474
		 40 0.0025800727642697474 45 0.0025800727642697474;
createNode animCurveTL -n "front_right_translateZ";
	rename -uid "AB2597B5-4002-66E6-BE0C-B9A1FEE047E4";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -0.36901830268138158 5 -0.36901830268138158
		 10 -0.36901830268138158 12 -0.36901830268138158 14 -0.36901830268138158 16 -0.36901830268138158
		 20 -0.36901830268138158 25 -0.36901830268138158 30 -0.36901830268138158 35 -0.36901830268138158
		 40 -0.36901830268138158 45 -0.36901830268138158;
createNode animCurveTL -n "joint1_translateX";
	rename -uid "57438EAB-45F6-27FA-9BA3-AA987EC9437A";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -0.010924558211334201 5 -0.010924558211334201
		 10 -0.010924558211334201 12 -0.010924558211334201 14 -0.010924558211334201 16 -0.010924558211334201
		 20 -0.010924558211334201 25 -0.010924558211334201 30 -0.010924558211334201 35 -0.010924558211334201
		 40 -0.010924558211334201 45 -0.010924558211334201;
createNode animCurveTL -n "joint1_translateY";
	rename -uid "E55BC77D-42B8-FE31-D07C-C5A427314341";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0.041049200626239069 5 0.041049200626239069
		 10 0.041049200626239069 12 0.60232425945399559 14 0.041049200626239069 16 0.041049200626239069
		 20 0.041049200626239069 25 0.041049200626239069 30 0.041049200626239069 35 0.041049200626239069
		 40 0.041049200626239069 45 0.041049200626239069;
createNode animCurveTL -n "joint1_translateZ";
	rename -uid "DE23746F-40F3-1DF7-0E3E-FB8A1F974525";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -0.5739497940079652 5 -0.5739497940079652
		 10 -0.5739497940079652 12 -0.5739497940079652 14 -0.5739497940079652 16 -0.5739497940079652
		 20 -0.5739497940079652 25 -0.5739497940079652 30 -0.5739497940079652 35 -0.5739497940079652
		 40 -0.5739497940079652 45 -0.5739497940079652;
createNode animCurveTL -n "joint2_translateX";
	rename -uid "B481E75B-4260-8B5A-0522-078479AF9E2C";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 13 ".ktv[0:12]"  1 0.025260638018724357 5 0.025260638018724357
		 10 0.025260638018724357 12 0.025260638018724135 14 0.025260638018723913 16 0.025260638018723913
		 19 0.025260638018723913 20 0.025260638018723913 25 0.025260638018723913 30 0.025260638018723469
		 35 0.025260638018723469 40 0.025260638018723469 45 0.025260638018723025;
createNode animCurveTL -n "joint2_translateY";
	rename -uid "BFD4D5E9-4FB0-052B-7C2F-5087C1635485";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 13 ".ktv[0:12]"  1 0.29633708208330845 5 0.29633708208330845
		 10 0.29633708208330845 12 0.45046881972104647 14 0.60460047467609446 16 0.60460047467609446
		 19 0.60460047467609446 20 0.60460047467609446 25 0.60460047467609446 30 0.36142929986183725
		 35 0.36142929986183725 40 0.36142929986183725 45 0.11842488755151642;
createNode animCurveTL -n "joint2_translateZ";
	rename -uid "40D18A46-4916-D790-2A5D-C1ABC7CE2B00";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 13 ".ktv[0:12]"  1 -0.72969579219536485 5 -0.72969579219536485
		 10 -0.72969579219536485 12 -0.75063311597887683 14 -0.77157042853073543 16 -0.77157042853073543
		 19 -0.77157042853073543 20 -0.77157042853073543 25 -0.77157042853073543 30 -0.73853794800508621
		 35 -0.73853794800508621 40 -0.73853794800508621 45 -0.70552812057213132;
createNode animCurveTL -n "joint3_translateX";
	rename -uid "6E4BE675-4682-0B21-9304-1E9455DF84D3";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -0.48200676027117528 5 -0.41240484470880084
		 10 -0.48200676027117528 12 -0.48200676027117528 14 -0.48200676027117528 16 -0.37841816416498469
		 20 -0.30051179176298631 25 -0.17986861150078287 30 -0.26137105811740408 35 -0.30044211323813158
		 40 -0.1161435657394474 45 -0.17747396408238644;
createNode animCurveTL -n "joint3_translateY";
	rename -uid "02A19BE6-4C31-3E49-23F7-4FA17D7EA75E";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0.080177081645515624 5 0.27984498904140082
		 10 0.32927381264136102 12 0.20472541373696146 14 0.080177081645515624 16 0.50604712754326886
		 20 0.57306178011798814 25 0.67683841046939042 30 0.34176821948216796 35 0.1811405764501039
		 40 0.06224091567912813 45 -0.35097348135425371;
createNode animCurveTL -n "joint3_translateZ";
	rename -uid "E1A28842-4C56-650E-8409-79BAF6E53AD4";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -0.96913406801846325 5 -0.84921216116835629
		 10 -1.0224043119900388 12 -0.99576918286015415 14 -0.96913406801846325 16 -1.1750267689219025
		 20 -0.99721694491150059 25 -0.72186664956226687 30 -0.55987238093705738 35 -0.482214749032217
		 40 -0.47890810049182714 45 -0.77346184865527401;
createNode animCurveTL -n "joint4_translateX";
	rename -uid "36838BF8-41A9-6E6F-9736-01A385F03865";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 10 0 12 0.090417636923726188 14 0
		 16 0.3762186131496511 20 0.43241024039668369 25 0.51901384155077934 30 0.045103586543998389
		 35 0.38068012426092951 40 0.21575670606481928 45 0.17350540735084222;
createNode animCurveTL -n "joint4_translateY";
	rename -uid "A5DF60D0-49A6-0B70-1D0D-A18C9BD6924A";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -0.68436987134253568 5 -0.68436987134253568
		 10 -0.68436987134253568 12 -0.24009905279606658 14 -0.68436987134253568 16 0.18837455198607012
		 20 0.43410126053852882 25 0.62207191255415983 30 0.49447055053841393 35 0.19246704288376396
		 40 -0.071687318817743415 45 -0.24580751808910817;
createNode animCurveTL -n "joint4_translateZ";
	rename -uid "04E8B977-4A47-CE0A-6DA9-1DB683E473D5";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -0.83596004998529949 5 -0.83596004998529949
		 10 -0.83596004998529949 12 -1.0679961578816464 14 -0.83596004998529949 16 -1.1215446819684036
		 20 -0.99902694855121899 25 -1.0957230268489679 30 -1.1629347677878399 35 -0.86046694242485933
		 40 -0.89438109061349369 45 -0.70579685582987173;
createNode animCurveTL -n "joint5_translateX";
	rename -uid "BD6F6F3A-4241-814A-8818-F7B8405D37F6";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0.017643260953545958 5 0.017643260953545958
		 10 0.017643260953545958 12 0.018075551197238963 14 0.017643260953545958 16 0.017643260953545958
		 20 0.15828969054614397 25 -0.13146307195537399 30 0.11652805004185345 35 0.25540665033083054
		 40 -0.082154082498975239 45 -0.082154082498975239;
createNode animCurveTL -n "joint5_translateY";
	rename -uid "3EADB85B-4F9D-1589-5E61-86BE0FEF791F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -0.25663870175345149 5 -0.25663870175345149
		 10 -0.25663870175345149 12 -0.29737249383372871 14 -0.25663870175345149 16 -0.25663870175345149
		 20 0.15293866704918443 25 -0.51955281066375336 30 0.089734436196747674 35 -0.17061428712992524
		 40 -0.39522573051381638 45 -0.39522573051381638;
createNode animCurveTL -n "joint5_translateZ";
	rename -uid "66EFF563-408F-4A2C-CFAD-258E9F3B434F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -1.098368936643717 5 -1.098368936643717
		 10 -1.098368936643717 12 -0.82449470402705294 14 -1.098368936643717 16 -1.098368936643717
		 20 -1.0226687012955427 25 -0.80372701181830397 30 -0.91731325420105958 35 -0.87141613050650468
		 40 -0.82942758732060806 45 -0.82942758732060806;
createNode animCurveTL -n "left_translateX";
	rename -uid "06989CF9-46AA-343D-AE56-2985CB1B8850";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -0.7343790344389225 5 -0.7343790344389225
		 10 -0.7343790344389225 12 -0.7343790344389225 14 -0.7343790344389225 16 -0.7343790344389225
		 20 -0.7343790344389225 24 -0.7343790344389225 30 -0.7343790344389225 35 -0.7343790344389225;
createNode animCurveTL -n "left_translateY";
	rename -uid "8CB54CD3-4438-C872-5161-F9827AB1DAF7";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0.0025800727642704135 5 0.0025800727642704135
		 10 0.0025800727642704135 12 0.0025800727642704135 14 0.0025800727642704135 16 0.0025800727642704135
		 20 0.0025800727642704135 24 0.0025800727642704135 30 0.0025800727642704135 35 0.0025800727642704135;
createNode animCurveTL -n "left_translateZ";
	rename -uid "8B900355-4421-4444-735D-91BE0B516E7A";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -0.039613986275271795 5 -0.039613986275271795
		 10 -0.039613986275271795 12 -0.039613986275271795 14 -0.039613986275271795 16 -0.039613986275271795
		 20 -0.039613986275271795 24 -0.039613986275271795 30 -0.039613986275271795 35 -0.039613986275271795;
createNode animCurveTL -n "joint11_translateX";
	rename -uid "521A4BD9-4641-5FB2-F672-AAB340F41813";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -0.23158858839500507 5 -0.23158858839500507
		 10 -0.23158858839500507 12 -0.23158858839500507 14 -0.23158858839500507 16 -0.23158858839500507
		 20 -0.23158858839500507 24 -0.23158858839500507 30 -0.23158858839500507 35 -0.23158858839500507;
createNode animCurveTL -n "joint11_translateY";
	rename -uid "06856D94-4B14-C0B7-EE9C-3F94E84565BB";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0.03222390441453471 5 0.03222390441453471
		 10 0.03222390441453471 12 0.55306367764312958 14 0.03222390441453471 16 0.31911290018032912
		 20 0.31911290018032912 24 0.31911290018032912 30 0.31911290018032912 35 0.31911290018032912;
createNode animCurveTL -n "joint11_translateZ";
	rename -uid "DCE71585-46DA-06E4-D25C-569431343183";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -0.905750751312143 5 -0.905750751312143
		 10 -0.905750751312143 12 -0.905750751312143 14 -0.905750751312143 16 -0.905750751312143
		 20 -0.905750751312143 24 -0.905750751312143 30 -0.905750751312143 35 -0.905750751312143;
createNode animCurveTL -n "joint12_translateX";
	rename -uid "6759B005-44C8-9A06-5776-9780F04C9239";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -0.090489711368360926 5 -0.090489711368360926
		 10 -0.090489711368360926 12 -0.090489711368360704 14 -0.090489711368360926 16 -0.090489711368360926
		 20 -0.090489711368360926 24 -0.090489711368360926 30 -0.090489711368360926 35 -0.090489711368360926;
createNode animCurveTL -n "joint12_translateY";
	rename -uid "C7DA5FCF-4503-DE82-4750-7D935AB5FB28";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0.62788333516111727 5 0.62788333516111727
		 10 0.62788333516111727 12 0.70720157125529226 14 0.62788333516111727 16 0.27969747513504961
		 20 0.93034404138709981 24 0.93034404138709981 30 0.39942210560481506 35 0.39942210560481506;
createNode animCurveTL -n "joint12_translateZ";
	rename -uid "183661F7-49ED-89FB-C7DB-9AB1CB375975";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -0.94367841855576584 5 -0.94367841855576584
		 10 -0.94367841855576584 12 -0.85402564764267352 14 -0.94367841855576584 16 -0.94367841855576584
		 20 -0.94367841855576584 24 -0.94367841855576584 30 -0.94367841855576584 35 -0.94367841855576584;
createNode animCurveTL -n "joint13_translateX";
	rename -uid "FD65A83A-4FB8-353E-963E-19A70149EFC2";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -0.310940578953665 5 -0.10622607037359788
		 10 -0.310940578953665 12 -0.31094057895366478 14 -0.310940578953665 16 -0.31094057895366511
		 20 -0.31094057895366534 24 -0.31094057895366556 30 -0.31094057895366556 35 -0.19587200022001436;
createNode animCurveTL -n "joint13_translateY";
	rename -uid "043AA4BD-4A7C-FA39-3AE9-E7B12969F06E";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0.066861405564552445 5 0.066861405564552237
		 10 0.066861405564552445 12 0.29315784426346891 14 0.066861405564552445 16 -0.30062063977200165
		 20 0.053385229650513275 24 0.76652192658674878 30 0.76652192658674878 35 -0.48668549243936715;
createNode animCurveTL -n "joint13_translateZ";
	rename -uid "F1705C61-4721-9ADE-1057-B6AF47EEEB8B";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -1.1342155398616742 5 -1.1342155398616727
		 10 -1.1342155398616742 12 -1.056825407971874 14 -1.1342155398616742 16 -1.0738149416360319
		 20 -0.80035283018848391 24 -0.51646127495505223 30 -0.51646127495505223 35 -0.95686304844257686;
createNode animCurveTL -n "joint14_translateX";
	rename -uid "3B5EC990-49D6-5933-BDB3-5C81F642BC8F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -0.025164063271675641 5 -0.025164063271675641
		 10 -0.025164063271675641 12 -0.025164063271675696 14 -0.025164063271675752 16 -0.025164063271675752
		 20 -0.025164063271675752 24 -0.025164063271675752 30 0.045704287546901617 35 -0.033130420841233119;
createNode animCurveTL -n "joint14_translateY";
	rename -uid "4EA9995E-4293-1C62-771F-6DA5DCE1FE5B";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -0.72092738410597867 5 -0.72092738410597867
		 10 -0.72092738410597867 12 -0.065432295816260949 14 -0.14880844121103617 16 -0.41184794713004058
		 20 0.45196499317881894 24 0.6036236551973877 30 -0.045718945110794926 35 0.67661668070808212;
createNode animCurveTL -n "joint14_translateZ";
	rename -uid "6CE6415C-4D02-3BE4-F55F-9EA98B068E36";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -0.66385114924105526 5 -0.66385114924105526
		 10 -0.66385114924105526 12 -1.1205623802365037 14 -1.0501358753712351 16 -1.0283726056666447
		 20 -1.0998424555227584 24 -1.1123903363173788 30 -1.6100199485162507 35 -1.0564514668194114;
createNode animCurveTL -n "joint15_translateX";
	rename -uid "5230D47F-4D5E-70DB-B1B8-4291612C5B3A";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -0.28439623572913497 5 -0.28439623572913497
		 10 -0.28439623572913497 12 -0.28439623572913497 14 -0.28439623572913497 16 -0.28439623572913497
		 20 -0.28439623572913508 24 -0.28439623572913508 30 -0.0041297978535614378 35 0.0019291227160488874;
createNode animCurveTL -n "joint15_translateY";
	rename -uid "63963E71-466A-C5C5-B620-AAA0AA5E23CD";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -0.22852947211710484 5 -0.22852947211710484
		 10 -0.22852947211710484 12 -0.42828298928837821 14 -0.22852947211710484 16 -0.12285248327077417
		 20 -1.2168096154730916 24 -1.2168096154730916 30 -0.93291253100067772 35 -0.35114292880816689;
createNode animCurveTL -n "joint15_translateZ";
	rename -uid "7636419F-4BD4-44EA-1791-E18CE7B2BB3F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -1.0265845673631802 5 -1.0265845673631802
		 10 -1.0265845673631802 12 -0.53722207349679552 14 -1.0265845673631802 16 -0.8807951553824318
		 20 -0.037855171455961192 24 -0.037855171455961192 30 0.040114800215630145 35 0.25230841569082496;
createNode animCurveTL -n "right_translateX";
	rename -uid "47BF6A4F-4832-E909-956D-908244EF085E";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0.73332297966453597 5 0.73332297966453597
		 10 0.73332297966453597 12 0.73332297966453597 14 0.73332297966453597 16 0.73332297966453597
		 20 0.73332297966453597 30 0.73332297966453597 35 0.73332297966453597;
createNode animCurveTL -n "right_translateY";
	rename -uid "8AA65DCE-461C-98A5-030B-038844927A2F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 -0.015059477345133576 5 -0.015059477345133576
		 10 -0.015059477345133576 12 -0.015059477345133576 14 -0.015059477345133576 16 -0.015059477345133576
		 20 -0.015059477345133576 30 -0.015059477345133576 35 -0.015059477345133576;
createNode animCurveTL -n "right_translateZ";
	rename -uid "D3F6D690-493A-002B-E93D-11AD041D7C1C";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 -0.062823689009367634 5 -0.062823689009367634
		 10 -0.062823689009367634 12 -0.062823689009367634 14 -0.062823689009367634 16 -0.062823689009367634
		 20 -0.062823689009367634 30 -0.062823689009367634 35 -0.062823689009367634;
createNode animCurveTL -n "joint28_translateX";
	rename -uid "44CA2708-4512-1145-B877-D0B27BF21277";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0.26067407157723554 5 0.26067407157723554
		 10 0.26067407157723554 12 0.26067407157723554 14 0.26067407157723554 16 0.26067407157723554
		 20 0.26067407157723554 30 0.26067407157723554 35 0.26067407157723554;
createNode animCurveTL -n "joint28_translateY";
	rename -uid "BC7FA3D2-4F9B-37D8-6D4E-798C518598FF";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0.056802594496349723 5 0.61098259424801538
		 10 0.056802594496349723 12 0.056802594496349723 14 0.056802594496349723 16 0.056802594496349723
		 20 0.056802594496349723 30 0.056802594496349723 35 0.056802594496349723;
createNode animCurveTL -n "joint28_translateZ";
	rename -uid "CAD4737B-40FD-C6D0-8629-E8939B9337EC";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 -0.88989433465837564 5 0.37094120624524224
		 10 -0.88989433465837564 12 -0.88989433465837564 14 -0.88989433465837564 16 -0.88989433465837564
		 20 -0.88989433465837564 30 -0.88989433465837564 35 -0.88989433465837564;
createNode animCurveTL -n "joint29_translateX";
	rename -uid "6ACEF11C-4486-DBF3-58CF-EB93EF2F96B8";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0.074762160734993088 5 0.074762160734993088
		 10 0.074762160734993088 12 0.074762160734993088 14 0.074762160734993088 16 0.074762160734993088
		 20 0.074762160734993088 30 0.074762160734993088 35 0.074762160734993088;
createNode animCurveTL -n "joint29_translateY";
	rename -uid "A25AD92C-4B75-9B3D-5927-11B7519C0830";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0.62030631378300116 5 0.32620339189119096
		 10 0.62030631378300116 12 0.11933447481272016 14 0.62030631378300116 16 0.62030631378300116
		 20 0.62030631378300116 30 0.62030631378300116 35 0.1726583996806158;
createNode animCurveTL -n "joint29_translateZ";
	rename -uid "1AC3422C-4453-4475-DADF-159E05609AE6";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 -0.92659146646153223 5 -0.20594634832425257
		 10 -0.92659146646153223 12 -0.77947802348107798 14 -0.92659146646153223 16 -0.92659146646153223
		 20 -0.92659146646153223 30 -0.92659146646153223 35 -0.79109375767052825;
createNode animCurveTL -n "joint30_translateX";
	rename -uid "3D4A159B-4ABE-A1F7-15C0-85BA22E74749";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0.29904864293997235 5 -0.24824589108921513
		 10 0.29904864293997235 12 0.29904864293997191 14 0.29904864293997147 16 0.29904864293996969
		 20 0.29904864293996969 30 0.2990486429399688 35 0.29904864293996791;
createNode animCurveTL -n "joint30_translateY";
	rename -uid "260CA2F5-4428-EEC2-A934-AB81A402CB88";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0.064321406494561861 5 -0.076786633436052909
		 10 0.064321406494561861 12 0.14974920131927238 14 -0.32359817792059192 16 1.5819601917377974
		 20 1.5819601917377974 30 0.50949700951728449 35 -0.33687279668036624;
createNode animCurveTL -n "joint30_translateZ";
	rename -uid "0BA38030-4DF4-8487-FABC-DF8A3D940B54";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 -1.1520210860833067 5 -0.82560275700460528
		 10 -1.1520210860833067 12 -1.1753556321894278 14 -1.034602433549632 16 -1.4028543384211383
		 20 -1.4028543384211383 30 -1.0782324662406904 35 -0.82204637463424557;
createNode animCurveTL -n "joint31_translateX";
	rename -uid "B1031DD1-4229-CCC2-6306-CF9DD34C34E1";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0.025654323647794186 5 -0.48812640651866213
		 10 0.025654323647794186 12 0.025654323647794408 14 0.02565432364779463 16 0.025654323647795404
		 20 0.025654323647794186 25 0.025654323647794186 30 0.025654323647794186 35 0.025654323647792854;
createNode animCurveTL -n "joint31_translateY";
	rename -uid "05831765-4919-66AC-2D5D-AD962CE1D38A";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -0.41974801652482874 5 -0.41974801652482796
		 10 -0.41974801652482874 12 -0.038737017236922994 14 -0.74583987989806744 16 -0.0069381527123053696
		 20 0.27960856478760504 25 -0.41974801652482874 30 -0.41974801652482874 35 -0.055406200729412318;
createNode animCurveTL -n "joint31_translateZ";
	rename -uid "079A560E-4A24-0663-C592-DF8E9D05BFCC";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -0.65886680125431507 5 -0.65886680125431496
		 10 -0.65886680125431507 12 -0.34277150142670626 14 -0.56016266581550345 16 -0.74608689393253169
		 20 -0.8705537351379633 25 -0.65886680125431507 30 -0.65886680125431507 35 -0.54197911266994225;
createNode animCurveTU -n "joint27_visibility";
	rename -uid "6A1E8870-4200-E0D2-3CAE-8B9408C26466";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
	setAttr -s 11 ".kot[0:10]"  5 5 5 5 5 5 5 5 
		5 5 5;
createNode animCurveTA -n "joint27_rotateX";
	rename -uid "5AFFD0F8-4EAF-FB20-ABC6-6D8D5A15E5D2";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "joint27_rotateY";
	rename -uid "FE847E7B-47A6-85AE-4F93-269C76F361D5";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "joint27_rotateZ";
	rename -uid "A7A57E8C-481F-599C-9B08-2A9760FD385B";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTU -n "joint27_scaleX";
	rename -uid "F61B9370-4071-8229-01DE-59A3F983C3C2";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint27_scaleY";
	rename -uid "9A9C29B1-47B4-4E49-BE93-1A8B44F32D58";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint27_scaleZ";
	rename -uid "745FCF44-47A1-B1F7-3371-7AB3820855FF";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint26_visibility";
	rename -uid "9C5C295D-4AD0-8214-3094-87ACC9448959";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
	setAttr -s 11 ".kot[0:10]"  5 5 5 5 5 5 5 5 
		5 5 5;
createNode animCurveTA -n "joint26_rotateX";
	rename -uid "A527EDCD-46B1-FFE9-04B6-0E80F0DDD013";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 -10.684485191979805 10 -33.530409037576938
		 12 2.5429013705240879 14 -20.538699041699228 16 22.760690538270605 20 22.760690538270605
		 25 22.760690538270605 30 22.760690538270605 35 22.760690538270605 40 22.760690538270605;
createNode animCurveTA -n "joint26_rotateY";
	rename -uid "A1118D38-4578-D6DB-4CA5-54BFFBB21CF1";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "joint26_rotateZ";
	rename -uid "DFB9DAC1-4424-C56A-68A5-1280CABEB973";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 2.8386998127474845 10 8.9085026211527758
		 12 9.7590265397140961 14 0 16 0 20 0 25 0 30 0 35 0 40 0;
createNode animCurveTU -n "joint26_scaleX";
	rename -uid "E177C3BB-400A-8101-4716-F4A7AFBC5ED5";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint26_scaleY";
	rename -uid "D3FFD578-42EF-71A8-9D18-80B399BEA6B5";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint26_scaleZ";
	rename -uid "2AA40B8D-4C52-CC7F-4038-A59BCBC94DE1";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint25_visibility";
	rename -uid "7D6E7108-4566-2449-45F6-95813179732C";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
	setAttr -s 11 ".kot[0:10]"  5 5 5 5 5 5 5 5 
		5 5 5;
createNode animCurveTA -n "joint25_rotateX";
	rename -uid "C09585E4-492A-5A01-10DE-3A84F57231A1";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 -7.115105244492681 10 -22.328861194335776
		 12 -24.460670694500759 14 -55.845073620657175 16 -20.861174422117472 20 -20.861174422117472
		 25 -20.861174422117472 30 -20.861174422117472 35 -15.354843743102492 40 -15.668469211907032;
createNode animCurveTA -n "joint25_rotateY";
	rename -uid "0A7BD732-411B-E43F-4016-088D3A3FE6E7";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 -8.7326641294445615
		 20 -8.7326641294445615 25 -8.7326641294445615 30 -8.7326641294445615 35 -16.703931608875795
		 40 -16.411153420727846;
createNode animCurveTA -n "joint25_rotateZ";
	rename -uid "D134DCBE-48D1-CF71-A7D8-A3B3BF9BAB5F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 25.493232034390303
		 20 25.493232034390303 25 25.493232034390303 30 25.493232034390303 35 0.90795707254695623
		 40 2.0084470095853537;
createNode animCurveTU -n "joint25_scaleX";
	rename -uid "A594CB30-4F2E-3EDB-4908-2AA706933CB5";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint25_scaleY";
	rename -uid "9BCA8329-47C2-4B03-BDB3-3FBD7324DEB0";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint25_scaleZ";
	rename -uid "886FAAD3-46F7-D2EF-A677-4FBDBB631B86";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint24_visibility";
	rename -uid "C136B9CC-4761-7D7F-07B9-2AABE94846FE";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
	setAttr -s 11 ".kot[0:10]"  5 5 5 5 5 5 5 5 
		5 5 5;
createNode animCurveTA -n "joint24_rotateX";
	rename -uid "DC87AE23-4508-D18E-1302-EFA40C539DB3";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "joint24_rotateY";
	rename -uid "76307837-4AFF-DF49-86D0-10A3032297A4";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0.77789201676363118 10 2.441206710947875
		 12 2.6742767100387983 14 0 16 0 20 0 25 0 30 0 35 0 40 0;
createNode animCurveTA -n "joint24_rotateZ";
	rename -uid "DD60E548-4B11-4900-DC79-25A872B2D31E";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTU -n "joint24_scaleX";
	rename -uid "7E5ABC61-4E50-2429-08C3-82A423F34452";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint24_scaleY";
	rename -uid "77A3B029-4A5C-D675-3BF0-BB914211C350";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint24_scaleZ";
	rename -uid "B3B6B6AD-4B1F-B9FF-AA26-87AF45AA88AC";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint23_visibility";
	rename -uid "7C1EC329-44E3-B2E7-3E64-6295AE18D1A6";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
	setAttr -s 11 ".kot[0:10]"  5 5 5 5 5 5 5 5 
		5 5 5;
createNode animCurveTA -n "joint23_rotateX";
	rename -uid "D14DA6D3-465C-035C-9715-C083705AFEB0";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "joint23_rotateY";
	rename -uid "47DB3859-4B04-E309-3F03-238BEFD2CBB9";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "joint23_rotateZ";
	rename -uid "425C37BE-4D88-18D8-9A1C-A0AEEE192406";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -79.210155372833739 5 -107.00967095680008
		 10 -7.8099173881278299 12 -8.5555557768754849 14 0 16 0 20 0 25 0 30 0 35 0 40 0;
createNode animCurveTU -n "joint23_scaleX";
	rename -uid "428FE0D0-4476-69A0-F877-04A2DDBF1A80";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint23_scaleY";
	rename -uid "3245EA70-4A3D-CEBD-F704-7198B533B105";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint23_scaleZ";
	rename -uid "20FE4446-40C9-1021-0F5C-D3A98EDF696F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint22_visibility";
	rename -uid "498A2A50-4862-AD7E-EEFC-C1AAFB5F249A";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
	setAttr -s 11 ".kot[0:10]"  5 5 5 5 5 5 5 5 
		5 5 5;
createNode animCurveTA -n "joint22_rotateX";
	rename -uid "4F04B408-4B8F-45CE-E1FE-7FB2AD3D2C42";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "joint22_rotateY";
	rename -uid "046949E7-40BD-BC65-F867-FDBFA3C752C1";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "joint22_rotateZ";
	rename -uid "7148D96C-46C5-A475-0786-32B6FD3CEC88";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 -37.080580200279108 5 -21.617622383716203
		 10 0 12 0 14 0 16 0 20 0 25 0 30 0 35 0 40 0;
createNode animCurveTU -n "joint22_scaleX";
	rename -uid "310F6166-41A9-11B2-46C3-AF8F9BC0383B";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint22_scaleY";
	rename -uid "D78E27F5-4490-B428-B8C6-76B4CE2D063E";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint22_scaleZ";
	rename -uid "D01344A4-4FA3-EAD0-887C-7A82087F5E24";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "back_right_visibility";
	rename -uid "A4C691BF-4373-F384-D48A-B98508A0B93C";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
	setAttr -s 11 ".kot[0:10]"  5 5 5 5 5 5 5 5 
		5 5 5;
createNode animCurveTA -n "back_right_rotateX";
	rename -uid "E817419C-4739-92DE-860E-43B0479576C4";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "back_right_rotateY";
	rename -uid "0C11A751-457B-FF93-61A0-278F7C5A6845";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "back_right_rotateZ";
	rename -uid "00C9258D-415D-3B27-B570-C58B6067381B";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTU -n "back_right_scaleX";
	rename -uid "13C7DD2A-435A-4935-05F2-738A51CEFC74";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "back_right_scaleY";
	rename -uid "95A5FE02-4105-989E-2088-4CBC0EB586F6";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "back_right_scaleZ";
	rename -uid "E6FB7AA6-4651-3E6E-C647-969283A17E90";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint21_visibility";
	rename -uid "D65982ED-4CE6-FAA0-DED6-FCBB1AF9C262";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
	setAttr -s 11 ".kot[0:10]"  5 5 5 5 5 5 5 5 
		5 5 5;
createNode animCurveTA -n "joint21_rotateX";
	rename -uid "EC28DA9D-4373-610C-0179-FEAC001CCF75";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 20.951393851741425 14 41.902776464281686
		 16 41.902776464281686 20 22.427511643528778 25 22.427511643528778 30 22.427511643528778
		 35 22.427511643528778 40 22.427511643528778;
createNode animCurveTA -n "joint21_rotateY";
	rename -uid "A361735B-4C0C-69DC-170A-38B3D30825F8";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "joint21_rotateZ";
	rename -uid "AC4D66DB-41B1-A823-28B1-0F989B63CEDC";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTU -n "joint21_scaleX";
	rename -uid "B1C04B9E-411F-B64F-EF94-E081C66AF7FA";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 0.63980445250372586 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1;
createNode animCurveTU -n "joint21_scaleY";
	rename -uid "F093B442-4BA7-471C-E4A8-2EB99B7CF006";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 0.53800625535174063 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1;
createNode animCurveTU -n "joint21_scaleZ";
	rename -uid "43A66EF3-4BAB-EF9B-0937-068DA7646169";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 0.63980445250372586 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1;
createNode animCurveTU -n "joint20_visibility";
	rename -uid "20B87CA0-4596-2C0A-E1A5-AE8E7C7DD9C8";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
	setAttr -s 11 ".kot[0:10]"  5 5 5 5 5 5 5 5 
		5 5 5;
createNode animCurveTA -n "joint20_rotateX";
	rename -uid "5459F32E-4FC5-7C57-178A-DEB953198F4B";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 7.6383345809265348
		 25 7.6383345809265348 30 7.6383345809265348 35 7.6383345809265348 40 7.6383345809265348;
createNode animCurveTA -n "joint20_rotateY";
	rename -uid "5DB25E15-4CE4-6787-1914-06933D19C915";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "joint20_rotateZ";
	rename -uid "ED7BD015-4E2D-59E5-F6D7-378289F95130";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTU -n "joint20_scaleX";
	rename -uid "FEB69C9A-4135-4D49-C06F-9BBF1D00FFED";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 0.43661251515006588 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1;
createNode animCurveTU -n "joint20_scaleY";
	rename -uid "E21848BB-426B-4D03-3AD2-6F8EC913095F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 0.43661251515006588 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1;
createNode animCurveTU -n "joint20_scaleZ";
	rename -uid "E82EAD81-473A-1EC1-D895-5EB5862B7F26";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 0.43661251515006588 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1;
createNode animCurveTU -n "joint19_visibility";
	rename -uid "D1449DE1-4A82-5B35-79B0-9893FE1DC4A9";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
	setAttr -s 11 ".kot[0:10]"  5 5 5 5 5 5 5 5 
		5 5 5;
createNode animCurveTA -n "joint19_rotateX";
	rename -uid "CC1F4FC0-4B5A-B0B5-1947-9DB41446F281";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 17.770553056494101
		 25 -5.9402006686345707 30 -5.9402006686345707 35 -5.9402006686345707 40 -5.9402006686345707;
createNode animCurveTA -n "joint19_rotateY";
	rename -uid "19C2E8EE-459B-AA44-AE05-B28A85B7E7C9";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "joint19_rotateZ";
	rename -uid "E8061C9F-4A41-51B7-2765-0C8B175D84C8";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTU -n "joint19_scaleX";
	rename -uid "6061D6DE-449B-FE46-7554-21AE3D9124FB";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 0.65733221879577919 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1;
createNode animCurveTU -n "joint19_scaleY";
	rename -uid "6BBE71D5-40B1-7A81-9CF8-6DAAB02269F0";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 0.65733221879577919 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1;
createNode animCurveTU -n "joint19_scaleZ";
	rename -uid "20909A80-4862-4499-DCD2-75B080D6686E";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 0.65733221879577919 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1;
createNode animCurveTU -n "joint18_visibility";
	rename -uid "D0CC57CD-4FC0-E5DF-85FD-A58511C634C6";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
	setAttr -s 11 ".kot[0:10]"  5 5 5 5 5 5 5 5 
		5 5 5;
createNode animCurveTA -n "joint18_rotateX";
	rename -uid "752D5A3B-431F-76C6-CC25-2CA12C813C53";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 -8.1488804852830903 14 -16.297756599166952
		 16 -16.297756599166952 20 -16.297756599166952 25 -16.297756599166952 30 -16.297756599166952
		 35 -16.297756599166952 40 -16.297756599166952;
createNode animCurveTA -n "joint18_rotateY";
	rename -uid "96A0B2C8-4930-320F-C435-E8A6DA0076FD";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "joint18_rotateZ";
	rename -uid "5D6AC93E-4E1A-9E2B-E7C5-5C8B1BB41D6E";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTU -n "joint18_scaleX";
	rename -uid "1411F1FE-4003-CA5B-EC07-80B25BA6D40F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 0.62493645293873157 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1;
createNode animCurveTU -n "joint18_scaleY";
	rename -uid "D71CB28A-47AC-CAB8-20C4-7BAB9E9B0187";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 0.62493645293873157 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1;
createNode animCurveTU -n "joint18_scaleZ";
	rename -uid "1F9EAEBA-454C-1DFF-0E79-6FAB38C88127";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 0.62493645293873157 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1;
createNode animCurveTU -n "joint17_visibility";
	rename -uid "0A4A5504-4A9C-2961-6A87-98B80F54D9FF";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
	setAttr -s 11 ".kot[0:10]"  5 5 5 5 5 5 5 5 
		5 5 5;
createNode animCurveTA -n "joint17_rotateX";
	rename -uid "0A825291-457C-DC86-82BB-648E0C8DF2B6";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "joint17_rotateY";
	rename -uid "05345FD2-483A-487A-591E-58906E5283EA";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "joint17_rotateZ";
	rename -uid "01B44044-4665-739F-56F0-79B6733E7283";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTU -n "joint17_scaleX";
	rename -uid "0315821D-46AE-32D9-EDF5-63840E83A200";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 0.70498530174753016 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1;
createNode animCurveTU -n "joint17_scaleY";
	rename -uid "0BE689DD-4726-905C-D9C0-A3B971EC2781";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 0.70498530174753016 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1;
createNode animCurveTU -n "joint17_scaleZ";
	rename -uid "6C6F135A-46C2-912C-2E31-189F04C5A080";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 0.70498530174753016 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1;
createNode animCurveTU -n "joint16_visibility";
	rename -uid "391FCD67-477E-04EF-2293-1D814264F8D2";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
	setAttr -s 11 ".kot[0:10]"  5 5 5 5 5 5 5 5 
		5 5 5;
createNode animCurveTA -n "joint16_rotateX";
	rename -uid "4CDF73D6-4EC0-45A8-F619-E89AB0CF2FE4";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "joint16_rotateY";
	rename -uid "64D00B66-4A01-1C3A-EB00-A3A921F72F1A";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "joint16_rotateZ";
	rename -uid "5E07FF81-40C6-EB09-FED9-E6B46660F326";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 101.91666519119443 5 59.416437682770976
		 10 0 12 0 14 0 16 0 20 0 25 0 30 0 35 0 40 0;
createNode animCurveTU -n "joint16_scaleX";
	rename -uid "CFCD54CE-4733-B829-2DCC-9291C2B5DB5E";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 0.71664041599241268 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1;
createNode animCurveTU -n "joint16_scaleY";
	rename -uid "8CC3DACD-418A-61BF-39DF-97A1131767E5";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 0.93154612150099148 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1;
createNode animCurveTU -n "joint16_scaleZ";
	rename -uid "F7C61407-4CAC-62DE-2711-ABB968C009A4";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 0.71664041599241268 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1;
createNode animCurveTU -n "back_left_visibility";
	rename -uid "D49A8387-4410-61D3-F20B-159437567C27";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
	setAttr -s 11 ".kot[0:10]"  5 5 5 5 5 5 5 5 
		5 5 5;
createNode animCurveTA -n "back_left_rotateX";
	rename -uid "5A2CB094-4208-C6B6-6EA9-93A93D28A0FC";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "back_left_rotateY";
	rename -uid "6C25FAE3-4B49-B9AB-2742-A38B34AE6BDF";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTA -n "back_left_rotateZ";
	rename -uid "B704EAF5-4C51-C201-E613-F09ED87881CE";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0;
createNode animCurveTU -n "back_left_scaleX";
	rename -uid "F1D41F7F-4ABD-4544-97C1-B793E2031A4A";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "back_left_scaleY";
	rename -uid "D7FD00AE-4218-E33A-40DC-FC90D925066A";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "back_left_scaleZ";
	rename -uid "CF9C5156-484E-9641-6430-E19F3F81536A";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 11 ".ktv[0:10]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1;
createNode animCurveTU -n "joint15_visibility";
	rename -uid "3AEB7AD6-45B1-A56B-0D40-15B0BC73C579";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 24 0 30 0
		 35 0;
	setAttr -s 10 ".kot[0:9]"  5 5 5 5 5 5 5 5 
		5 5;
createNode animCurveTA -n "joint15_rotateX";
	rename -uid "40779EDB-40A8-83D9-CCE0-F99A8ACF3432";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 0 14 0 16 -17.911907510966127
		 20 -17.911907510966127 24 -17.911907510966127 30 -17.911907510966127 35 -61.767431092978676;
createNode animCurveTA -n "joint15_rotateY";
	rename -uid "D0ABDBFD-4F98-2B31-26EF-47B8DBE4B592";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 24 0 30 0
		 35 -26.394376521782842;
createNode animCurveTA -n "joint15_rotateZ";
	rename -uid "DA3EE6FF-4BD6-C91F-575C-6EA9745BB794";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 24 0 30 0
		 35 39.622945503124846;
createNode animCurveTU -n "joint15_scaleX";
	rename -uid "ACF7B920-42CF-5D27-CC2C-56BD3EE96822";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 24 1 30 1
		 35 1;
createNode animCurveTU -n "joint15_scaleY";
	rename -uid "F514E3DF-49F2-7CC2-3D36-EC9961894B03";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 24 1 30 1
		 35 1;
createNode animCurveTU -n "joint15_scaleZ";
	rename -uid "E6D35D3B-4194-F6C9-B8C1-DBA63ABB0D97";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 24 1 30 1
		 35 1;
createNode animCurveTU -n "joint14_visibility";
	rename -uid "B9C7BFC4-426D-06EB-54BB-99BB402CFB02";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 24 0 30 0
		 35 0;
	setAttr -s 10 ".kot[0:9]"  5 5 5 5 5 5 5 5 
		5 5;
createNode animCurveTA -n "joint14_rotateX";
	rename -uid "A024C7F2-4470-E22F-AA4A-85B2ECA47360";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 -57.710304083038508 14 -64.757142746624552
		 16 31.20712815905943 20 31.20712815905943 24 31.20712815905943 30 107.37767163140228
		 35 107.37767163140228;
createNode animCurveTA -n "joint14_rotateY";
	rename -uid "10053B18-4A45-0C25-D315-70A265BEC55E";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 24 0 30 0
		 35 0;
createNode animCurveTA -n "joint14_rotateZ";
	rename -uid "2667A389-4829-E6C1-F196-44B3A75A3172";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 24 0 30 0
		 35 0;
createNode animCurveTU -n "joint14_scaleX";
	rename -uid "1565AA22-4BBD-BBC7-FC7B-979719167F9C";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 24 1 30 1
		 35 1;
createNode animCurveTU -n "joint14_scaleY";
	rename -uid "965EB27C-48EA-1AAE-153C-578F6DC922B4";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 24 1 30 1
		 35 1;
createNode animCurveTU -n "joint14_scaleZ";
	rename -uid "4971C310-4542-7BB0-9223-F3B5B417B68C";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 0.11247402238697714 10 1 12 1 14 1
		 16 1 20 1 24 1 30 1 35 1;
createNode animCurveTU -n "joint13_visibility";
	rename -uid "0C5EE12F-4240-F230-0071-8CA47BA67142";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 24 0 30 0
		 35 0;
	setAttr -s 10 ".kot[0:9]"  5 5 5 5 5 5 5 5 
		5 5;
createNode animCurveTA -n "joint13_rotateX";
	rename -uid "C3BACFD5-42EB-4070-C16A-9D95B6D65165";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 2.7851103055328195 14 5.5702191170163573
		 16 -4.6041285738960873 20 -4.6041285738960873 24 -4.6041285738960873 30 -18.10259948324271
		 35 -18.10259948324271;
createNode animCurveTA -n "joint13_rotateY";
	rename -uid "D7D53CAB-40E0-D695-00DC-7188EE5F05EB";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 24 0 30 0
		 35 0;
createNode animCurveTA -n "joint13_rotateZ";
	rename -uid "9C5849D6-4936-DEED-9BCD-ECBB9EB2101B";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 24 0 30 0
		 35 0;
createNode animCurveTU -n "joint13_scaleX";
	rename -uid "2B6783F8-4778-D5EB-7101-D9A61402EF43";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 24 1 30 1
		 35 1;
createNode animCurveTU -n "joint13_scaleY";
	rename -uid "3A7A4265-44B3-C270-C519-2D9AB49413E7";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 24 1 30 1
		 35 1;
createNode animCurveTU -n "joint13_scaleZ";
	rename -uid "9C4970DA-42F6-FC5B-5E48-328D1296C046";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 0.3218342242889658 10 1 12 1 14 1
		 16 1 20 1 24 1 30 1 35 1;
createNode animCurveTU -n "joint12_visibility";
	rename -uid "0002DF44-4A76-993F-DC28-43BFA0EB9696";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 24 0 30 0
		 35 0;
	setAttr -s 10 ".kot[0:9]"  5 5 5 5 5 5 5 5 
		5 5;
createNode animCurveTA -n "joint12_rotateX";
	rename -uid "A499BDBA-442F-FD0B-EF44-08B2CF95F5CE";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 24.504163029628366 14 28.456315687162974
		 16 9.3338736481926556 20 9.3338736481926556 24 9.3338736481926556 30 -19.313918148755597
		 35 -19.313918148755597;
createNode animCurveTA -n "joint12_rotateY";
	rename -uid "092FBE98-46B2-5812-5859-82B07F74DF5F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 24 0 30 -0.56057218106818452
		 35 -0.56057218106818452;
createNode animCurveTA -n "joint12_rotateZ";
	rename -uid "4BACC6FD-40AA-A596-003E-C0BB529421E8";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 24 0 30 -4.9511801400733884
		 35 -4.9511801400733884;
createNode animCurveTU -n "joint12_scaleX";
	rename -uid "2B40E892-48A3-9B45-3B12-2D9C98D94E83";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 24 1 30 1
		 35 1;
createNode animCurveTU -n "joint12_scaleY";
	rename -uid "4988640C-4744-D729-3007-8EBFF6D97C26";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 24 1 30 1
		 35 1;
createNode animCurveTU -n "joint12_scaleZ";
	rename -uid "A14344E4-45F3-949B-4E97-889DDBAB1DB7";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 0.26507517622854904 10 1 12 1 14 1
		 16 1 20 1 24 1 30 1 35 1;
createNode animCurveTU -n "joint11_visibility";
	rename -uid "CBD21480-4129-146E-55C5-8982C70F6942";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 24 0 30 0
		 35 0;
	setAttr -s 10 ".kot[0:9]"  5 5 5 5 5 5 5 5 
		5 5;
createNode animCurveTA -n "joint11_rotateX";
	rename -uid "561F1210-437F-2EC4-B4BE-BDA2FA7F4662";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 8.2161748803148296 14 0
		 16 0 20 0 24 0 30 0 35 0;
createNode animCurveTA -n "joint11_rotateY";
	rename -uid "4859BD90-4706-666B-3B4B-328A9E9B1F95";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 24 0 30 0
		 35 0;
createNode animCurveTA -n "joint11_rotateZ";
	rename -uid "1700E409-4996-D6FA-D578-DAA73B97A270";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 24 0 30 0
		 35 0;
createNode animCurveTU -n "joint11_scaleX";
	rename -uid "478F43E7-4AF0-8778-1814-90A9A420566C";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 24 1 30 1
		 35 1;
createNode animCurveTU -n "joint11_scaleY";
	rename -uid "BB40E38A-4B0B-1F2E-F2C6-2E97931C96F7";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 24 1 30 1
		 35 1;
createNode animCurveTU -n "joint11_scaleZ";
	rename -uid "ABBEFD8F-4CF6-304F-C0FF-9C93FC377613";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 0.15981519231531119 10 1 12 1 14 1
		 16 1 20 1 24 1 30 1 35 1;
createNode animCurveTU -n "left_visibility";
	rename -uid "47FC0B84-462D-A13A-077E-15B6E12000BE";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 24 0 30 0
		 35 0;
	setAttr -s 10 ".kot[0:9]"  5 5 5 5 5 5 5 5 
		5 5;
createNode animCurveTA -n "left_rotateX";
	rename -uid "4FE15DBA-4CC6-D5FD-42BE-2BA7C62C833F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 -69.094760513900155 5 -40.281582257214943
		 10 0 12 0 14 0 16 0 20 0 24 0 30 0 35 0;
createNode animCurveTA -n "left_rotateY";
	rename -uid "C4D54750-400C-4382-3AA7-8FA166B8F19F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 24 0 30 0
		 35 0;
createNode animCurveTA -n "left_rotateZ";
	rename -uid "976F2BC1-4130-0DC5-EB56-60B292C3A4AE";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 24 0 30 0
		 35 0;
createNode animCurveTU -n "left_scaleX";
	rename -uid "168C4398-4D6F-DB82-31F3-FF96B790B720";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 24 1 30 1
		 35 1;
createNode animCurveTU -n "left_scaleY";
	rename -uid "D44A22FD-4627-8287-303E-0E8F5C5C3F3F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 24 1 30 1
		 35 1;
createNode animCurveTU -n "left_scaleZ";
	rename -uid "3B2C9F1D-4827-735C-7178-61A22AD796D0";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 0.23960810253459947 10 1 12 1 14 1
		 16 1 20 1 24 1 30 1 35 1;
createNode animCurveTU -n "joint10_visibility";
	rename -uid "54496C94-40DA-CD13-5CCA-D2A78463F458";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 1 10 1 12 1 14 0 15 0 16 0 20 0
		 25 0 30 0 35 0;
	setAttr -s 12 ".kot[0:11]"  5 5 5 5 5 5 5 5 
		5 5 5 5;
createNode animCurveTA -n "joint10_rotateX";
	rename -uid "D033AE13-4B4C-605B-225C-0E9CAB2EE235";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 -12.702954817539471 8 -20.94766301420821
		 10 -15.516788527779228 12 -6.0127537058865794 14 0 15 0 16 0 20 0 25 0 30 0 35 0;
createNode animCurveTA -n "joint10_rotateY";
	rename -uid "A7CF5F85-434E-90F4-C11D-80A076847E88";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 0 10 0 12 0 14 0 15 0 16 0 20 0
		 25 0 30 0 35 0;
createNode animCurveTA -n "joint10_rotateZ";
	rename -uid "285D8B63-4B02-F9EE-E9DB-3AA82770BFB0";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 0 10 0 12 0 14 0 15 0 16 0 20 0
		 25 0 30 0 35 0;
createNode animCurveTU -n "joint10_scaleX";
	rename -uid "94739C9D-4EDA-5ABC-2FE6-FB8B1C832BD5";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 8 1 10 1 12 1 14 1 15 1 16 1 20 1
		 25 1 30 1 35 1;
createNode animCurveTU -n "joint10_scaleY";
	rename -uid "53477F07-463C-D436-97B9-EC8E4F2C05F2";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 8 1 10 1 12 1 14 1 15 1 16 1 20 1
		 25 1 30 1 35 1;
createNode animCurveTU -n "joint10_scaleZ";
	rename -uid "F04C830A-4286-530A-DBFE-6195E2DE1D49";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 8 1 10 1 12 1 14 1 15 1 16 1 20 1
		 25 1 30 1 35 1;
createNode animCurveTU -n "joint9_visibility";
	rename -uid "8A3B3DC3-43D4-086D-0A51-4D980E8DDF25";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 1 10 1 12 1 14 0 15 0 16 0 20 0
		 25 0 30 0 35 0;
	setAttr -s 12 ".kot[0:11]"  5 5 5 5 5 5 5 5 
		5 5 5 5;
createNode animCurveTA -n "joint9_rotateX";
	rename -uid "AF9A3486-47A8-55B4-2CC5-EEAFCD69D90C";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 0 10 0 12 -27.759313300888536
		 14 -30.21284544940454 15 -30.21284544940454 16 -30.21284544940454 20 -30.21284544940454
		 25 -30.21284544940454 30 -30.21284544940454 35 -52.845652911852717;
createNode animCurveTA -n "joint9_rotateY";
	rename -uid "093C6261-4615-F527-405E-1A9C9235A668";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 0 10 0 12 0 14 0 15 0 16 0 20 0
		 25 0 30 0 35 -8.1635206375097766;
createNode animCurveTA -n "joint9_rotateZ";
	rename -uid "FB8C20F7-441A-20B5-391F-BB988E4787DA";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 0 10 0 12 0 14 0 15 0 16 0 20 0
		 25 0 30 0 35 10.613360036949173;
createNode animCurveTU -n "joint9_scaleX";
	rename -uid "1EFCD31A-4C58-63F6-4A94-A39E47110DB3";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 8 1 10 1 12 1 14 1 15 1 16 1 20 1
		 25 1 30 1 35 1;
createNode animCurveTU -n "joint9_scaleY";
	rename -uid "46ED7A5D-4855-B50B-7DF3-7EA4350F6544";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 8 1 10 1 12 1 14 1 15 1 16 1 20 1
		 25 1 30 1 35 1;
createNode animCurveTU -n "joint9_scaleZ";
	rename -uid "F209A8F8-4F2F-B43C-D153-2895DBDE1CD7";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 0.3205664171171595 8 1 10 1 12 1 14 1
		 15 1 16 1 20 1 25 1 30 1 35 1;
createNode animCurveTU -n "joint8_visibility";
	rename -uid "B3D70E94-4990-DD88-E4E2-69A08EF505D8";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 1 10 1 12 1 14 0 15 0 16 0 20 0
		 25 0 30 0 35 0;
	setAttr -s 12 ".kot[0:11]"  5 5 5 5 5 5 5 5 
		5 5 5 5;
createNode animCurveTA -n "joint8_rotateX";
	rename -uid "8ACFD6C0-4937-FBB2-B9A4-E696A58D1AE3";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 0 10 0 12 0 14 0 15 -7.6739082070897968
		 16 0 20 10.419908914569405 25 10.419908914569405 30 10.419908914569405 35 10.419908914569405;
createNode animCurveTA -n "joint8_rotateY";
	rename -uid "65EF0DE3-43C4-96A0-EBB9-8B92140EE9C8";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 0 10 0 12 0 14 0 15 0 16 0 20 -0.94364801897280315
		 25 -0.94364801897280315 30 -0.94364801897280315 35 -0.94364801897280315;
createNode animCurveTA -n "joint8_rotateZ";
	rename -uid "32544C07-4B90-0987-BB12-19A19440B3B5";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 0 10 0 12 0 14 0 15 0 16 0 20 -3.8828600073219435
		 25 -3.8828600073219435 30 -3.8828600073219435 35 -3.8828600073219435;
createNode animCurveTU -n "joint8_scaleX";
	rename -uid "30051B74-4FE6-E00D-F846-258BA0100864";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 8 1 10 1 12 1 14 1 15 1 16 1 20 1
		 25 1 30 1 35 1;
createNode animCurveTU -n "joint8_scaleY";
	rename -uid "05343A1A-4F53-652C-CC30-398395E49C84";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 8 1 10 1 12 1 14 1 15 1 16 1 20 1
		 25 1 30 1 35 1;
createNode animCurveTU -n "joint8_scaleZ";
	rename -uid "FF309EB5-4AD1-F7FB-2756-A5B7C289365C";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 0.4134430173764499 8 1 10 1 12 1 14 1
		 15 1 16 1 20 1 25 1 30 1 35 1;
createNode animCurveTU -n "joint7_visibility";
	rename -uid "CE49A8BF-446C-16DF-FBE0-FDBC648E7704";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 1 10 1 12 1 14 0 15 0 16 0 20 0
		 25 0 30 0 35 0;
	setAttr -s 12 ".kot[0:11]"  5 5 5 5 5 5 5 5 
		5 5 5 5;
createNode animCurveTA -n "joint7_rotateX";
	rename -uid "980C7098-497B-23B8-FD46-DA9C87398F1A";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 17.453505344292559 8 28.781504273644284
		 10 21.319634320191167 12 8.2613558755741625 14 0 15 0 16 0 20 0 25 16.543053726807671
		 30 16.543053726807671 35 16.543053726807671;
createNode animCurveTA -n "joint7_rotateY";
	rename -uid "2EF0C5C7-407B-702F-94ED-388474335F75";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 0 10 0 12 0 14 0 15 0 16 0 20 0
		 25 0 30 0 35 0;
createNode animCurveTA -n "joint7_rotateZ";
	rename -uid "6F799811-4FBC-76C2-5491-89AB297A16E0";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 0 10 0 12 0 14 0 15 0 16 0 20 0
		 25 0 30 0 35 0;
createNode animCurveTU -n "joint7_scaleX";
	rename -uid "A7A05D0F-4D6C-BD14-CB35-DA96C2F58F04";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 8 1 10 1 12 1 14 1 15 1 16 1 20 1
		 25 1 30 1 35 1;
createNode animCurveTU -n "joint7_scaleY";
	rename -uid "7B09CDA0-4EEB-9005-40BD-90A60197EDDA";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 8 1 10 1 12 1 14 1 15 1 16 1 20 1
		 25 1 30 1 35 1;
createNode animCurveTU -n "joint7_scaleZ";
	rename -uid "C89D714B-4338-0288-10FE-B5AF4755DEE5";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 0.52845929085577104 8 1 10 1 12 1
		 14 1 15 1 16 1 20 1 25 1 30 1 35 1;
createNode animCurveTU -n "joint6_visibility";
	rename -uid "5ABA1FDE-484B-AB93-E525-2FAA38EE5AC0";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 1 10 1 12 1 14 0 15 0 16 0 20 0
		 25 0 30 0 35 0;
	setAttr -s 12 ".kot[0:11]"  5 5 5 5 5 5 5 5 
		5 5 5 5;
createNode animCurveTA -n "joint6_rotateX";
	rename -uid "AA3965D6-444A-97EE-B3C8-C1B17339C7EC";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 0 10 0 12 7.4388071217274083 14 14.877610252968546
		 15 14.877610252968546 16 14.877610252968546 20 14.877610252968546 25 14.877610252968546
		 30 14.877610252968546 35 14.877610252968546;
createNode animCurveTA -n "joint6_rotateY";
	rename -uid "D4A54E44-4905-BE48-BDF7-1396DEBC88B9";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 0 10 0 12 0 14 0 15 0 16 0 20 0
		 25 0 30 0 35 0;
createNode animCurveTA -n "joint6_rotateZ";
	rename -uid "2C2B4D71-4067-899A-5EC4-369BB5E04F90";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 0 10 0 12 0 14 0 15 0 16 0 20 0
		 25 0 30 0 35 0;
createNode animCurveTU -n "joint6_scaleX";
	rename -uid "678F69FA-4EFB-0BC8-A3D5-898192E0F377";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 8 1 10 1 12 1 14 1 15 1 16 1 20 1
		 25 1 30 1 35 1;
createNode animCurveTU -n "joint6_scaleY";
	rename -uid "3C4D6353-4B0A-64DB-02B9-2F926909C965";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 8 1 10 1 12 1 14 1 15 1 16 1 20 1
		 25 1 30 1 35 1;
createNode animCurveTU -n "joint6_scaleZ";
	rename -uid "02A02B28-45CD-E95E-A73A-C5A44CAD6A6C";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 0.46200542714725196 8 1 10 1 12 1
		 14 1 15 1 16 1 20 1 25 1 30 1 35 1;
createNode animCurveTU -n "front_left_visibility";
	rename -uid "6F546A10-4661-2414-31F8-D1838447970C";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 1 10 1 12 1 14 0 15 0 16 0 20 0
		 25 0 30 0 35 0;
	setAttr -s 12 ".kot[0:11]"  5 5 5 5 5 5 5 5 
		5 5 5 5;
createNode animCurveTA -n "front_left_rotateX";
	rename -uid "8FF58722-43C9-3B2A-3B64-3EAC47160539";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -70.04882015190951 5 -27.570239280711117
		 8 0 10 0 12 0 14 0 15 0 16 0 20 0 25 0 30 0 35 0;
createNode animCurveTA -n "front_left_rotateY";
	rename -uid "631B9FD5-49C0-8451-00B3-0FB0678F48B6";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 0 10 0 12 0 14 0 15 0 16 0 20 0
		 25 0 30 0 35 0;
createNode animCurveTA -n "front_left_rotateZ";
	rename -uid "CA4E64B6-43C0-C1B5-5B13-FEB05B8A9BD7";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 8 0 10 0 12 0 14 0 15 0 16 0 20 0
		 25 0 30 0 35 0;
createNode animCurveTU -n "front_left_scaleX";
	rename -uid "DA845F33-4C86-E1E8-D2C9-4C9D9AF7FB99";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 0.91076633213126468 8 1 10 1 12 1
		 14 1 15 1 16 1 20 1 25 1 30 1 35 1;
createNode animCurveTU -n "front_left_scaleY";
	rename -uid "7A9AC8FF-49E0-3433-23EB-5DA7AC913F5A";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 0.91076633213126468 8 1 10 1 12 1
		 14 1 15 1 16 1 20 1 25 1 30 1 35 1;
createNode animCurveTU -n "front_left_scaleZ";
	rename -uid "DB7B89EC-47BD-2399-BBFC-A4AF0B8C2B0E";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 0.33361536018136173 8 1 10 1 12 1
		 14 1 15 1 16 1 20 1 25 1 30 1 35 1;
createNode animCurveTU -n "joint5_visibility";
	rename -uid "EA528AEF-48D6-0FF9-E629-80B6A21382CE";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0 45 0;
	setAttr -s 12 ".kot[0:11]"  5 5 5 5 5 5 5 5 
		5 5 5 5;
createNode animCurveTA -n "joint5_rotateX";
	rename -uid "0005520B-47FC-82CB-8CBE-128760646B84";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 -5.7490228470966525 10 0 12 0 14 0
		 16 0 20 0 25 0 30 0 35 0 40 0 45 0;
createNode animCurveTA -n "joint5_rotateY";
	rename -uid "6D857640-4E8E-BBFE-3E43-AC9A3135A3BD";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0 45 0;
createNode animCurveTA -n "joint5_rotateZ";
	rename -uid "79737CF4-4557-7F9B-C637-6CA8734D0436";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0 45 0;
createNode animCurveTU -n "joint5_scaleX";
	rename -uid "BEF48753-40A1-AA86-F4EE-58A938B56A9D";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1 45 1;
createNode animCurveTU -n "joint5_scaleY";
	rename -uid "19D096E0-4B65-1AB6-DA9B-ED9936BEFA02";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1 45 1;
createNode animCurveTU -n "joint5_scaleZ";
	rename -uid "2E0EDAEE-4227-C73E-D13C-77AF66E3CA03";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1 45 1;
createNode animCurveTU -n "joint4_visibility";
	rename -uid "81BFCF9D-4685-1100-6691-4CBA78CC1CE1";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0 45 0;
	setAttr -s 12 ".kot[0:11]"  5 5 5 5 5 5 5 5 
		5 5 5 5;
createNode animCurveTA -n "joint4_rotateX";
	rename -uid "9AF6AAD1-400B-F6D9-BA45-E9B7A7A020BF";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 -35.288835754151023 10 0 12 -25.628174326103942
		 14 36.681825559258549 16 -24.230337010580474 20 -9.1886574358533544 25 -9.1886574358533544
		 30 -9.1886574358533544 35 -8.898403837949715 40 -1.7034194686821549 45 -27.901735469876371;
createNode animCurveTA -n "joint4_rotateY";
	rename -uid "DB98ADEA-40D7-9767-2691-2CA119AA4E4C";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 -2.3005345636521435 40 0 45 0;
createNode animCurveTA -n "joint4_rotateZ";
	rename -uid "62127ABD-47FC-3CBF-4028-D6BB29E75D4A";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 -14.379903848141954 40 0 45 0;
createNode animCurveTU -n "joint4_scaleX";
	rename -uid "5FC318FB-425C-CA99-80AE-3B92B211B743";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1 45 1;
createNode animCurveTU -n "joint4_scaleY";
	rename -uid "C2A05A58-4AB3-0B31-D8E6-5DA253B4F8D9";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1 45 1;
createNode animCurveTU -n "joint4_scaleZ";
	rename -uid "B5FFF742-4D1D-AC34-1741-4EAF56E7D195";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 0.25958908600337921 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1 45 1;
createNode animCurveTU -n "joint3_visibility";
	rename -uid "579F99B0-4461-5DB1-9853-E1B6C0695F8A";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0 45 0;
	setAttr -s 12 ".kot[0:11]"  5 5 5 5 5 5 5 5 
		5 5 5 5;
createNode animCurveTA -n "joint3_rotateX";
	rename -uid "300024F5-4041-C113-70D4-5684B9704D40";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 -30.396944947270441 10 -6.321209659246291
		 12 5.9608469846851024 14 0 16 0 20 9.102807939110253 25 9.102807939110253 30 9.102807939110253
		 35 -10.018522799625989 40 -23.482778040183032 45 -23.482778040183032;
createNode animCurveTA -n "joint3_rotateY";
	rename -uid "0B31A2C7-45B3-7427-19D8-1EAC0E7920E1";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 -2.5869646946807565 40 0 45 0;
createNode animCurveTA -n "joint3_rotateZ";
	rename -uid "37133E4D-4119-FF33-8739-2BBF789FC4F1";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 -14.33214193580825 40 0 45 0;
createNode animCurveTU -n "joint3_scaleX";
	rename -uid "99311148-4B7C-6CB0-235F-C38AA7C9806F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1 45 1;
createNode animCurveTU -n "joint3_scaleY";
	rename -uid "6E2A9BC9-470E-7919-0496-96B0CB188329";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1 45 1;
createNode animCurveTU -n "joint3_scaleZ";
	rename -uid "FEEE53D0-489D-AA49-C476-D5A88042C046";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 0.68551908680142348 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1 45 1;
createNode animCurveTU -n "joint2_visibility";
	rename -uid "14348EA2-47CD-5B09-38BD-CFB6BAD01D18";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 13 ".ktv[0:12]"  1 0 5 0 10 1 12 1 14 0 16 0 19 0 20 0 25 0
		 30 0 35 0 40 0 45 0;
	setAttr -s 13 ".kot[0:12]"  5 5 5 5 5 5 5 5 
		5 5 5 5 5;
createNode animCurveTA -n "joint2_rotateX";
	rename -uid "F5DE09E4-4590-B0AE-A9C9-24985274F964";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 13 ".ktv[0:12]"  1 0 5 0 10 0 12 23.80812180127241 14 0 16 20.650898542432817
		 19 27.315195125950673 20 20.650898542432817 25 27.214963173638147 30 29.253158410442339
		 35 25.404269842479763 40 27.535084060025994 45 27.535084060025994;
createNode animCurveTA -n "joint2_rotateY";
	rename -uid "03A15653-4DAD-6177-3B62-32B695891D10";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 13 ".ktv[0:12]"  1 -26.09029664503678 5 -26.09029664503678
		 10 -26.09029664503678 12 -26.090296645036798 14 -26.09029664503678 16 -22.293241837102954
		 19 -12.976974602475419 20 -22.293241837102954 25 -13.199163378129612 30 -7.0868066681654618
		 35 -16.567161428904921 40 -12.471666838133261 45 -12.471666838133261;
createNode animCurveTA -n "joint2_rotateZ";
	rename -uid "FD88D0C2-4667-F2CB-B170-FD95A29C5B0B";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 13 ".ktv[0:12]"  1 0 5 0 10 0 12 8.8535445782245416e-016
		 14 0 16 13.367821805618817 19 -8.3193036960323834 20 13.367821805618817 25 -7.8766807726413735
		 30 -19.396208752280263 35 -0.83835603295920802 40 -9.3175840364350524 45 -9.3175840364350524;
createNode animCurveTU -n "joint2_scaleX";
	rename -uid "BF46F01B-4B60-E5D0-A792-8DAEC4B40C32";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 13 ".ktv[0:12]"  1 1 5 1 10 1 12 1 14 1 16 1 19 1 20 1 25 1
		 30 1 35 1 40 1 45 1;
createNode animCurveTU -n "joint2_scaleY";
	rename -uid "EC3864EF-49F4-EE9D-7F81-7DBB04043F61";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 13 ".ktv[0:12]"  1 1 5 1 10 1 12 1 14 1 16 1 19 1 20 1 25 1
		 30 1 35 1 40 1 45 1;
createNode animCurveTU -n "joint2_scaleZ";
	rename -uid "24A36E15-48AD-720E-1802-0B8F0587A2A5";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 13 ".ktv[0:12]"  1 1 5 0.77053823378708586 10 1 12 1 14 1
		 16 1 19 1 20 1 25 1 30 1 35 1 40 1 45 1;
createNode animCurveTU -n "joint1_visibility";
	rename -uid "B4730FC7-41EA-A3E7-F789-BDAB167A9538";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0 45 0;
	setAttr -s 12 ".kot[0:11]"  5 5 5 5 5 5 5 5 
		5 5 5 5;
createNode animCurveTA -n "joint1_rotateX";
	rename -uid "A6C0A473-424E-A781-00FC-C585A3DFEC09";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 7.7357345270432161 5 7.7357345270432161
		 10 7.7357345270432161 12 7.7357345270432161 14 7.7357345270432161 16 7.7357345270432161
		 20 7.7357345270432161 25 7.7357345270432161 30 7.7357345270432161 35 7.7357345270432161
		 40 7.7357345270432161 45 7.7357345270432161;
createNode animCurveTA -n "joint1_rotateY";
	rename -uid "240C23E4-44E7-E915-C022-419ECCC099B0";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0 45 0;
createNode animCurveTA -n "joint1_rotateZ";
	rename -uid "078A6526-4A12-3AE7-C72E-A38EA634677E";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0 45 0;
createNode animCurveTU -n "joint1_scaleX";
	rename -uid "57B959DB-4BA7-E2D8-CFAF-3096519BE6B2";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1 45 1;
createNode animCurveTU -n "joint1_scaleY";
	rename -uid "04D3C723-4046-A82F-B7D9-9C9C49ACBB8F";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1 45 1;
createNode animCurveTU -n "joint1_scaleZ";
	rename -uid "DB21A752-49A5-BF0A-42B1-7AA9E383F4AA";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 0.18325616018524629 10 1 12 1 14 1
		 16 1 20 1 25 1 30 1 35 1 40 1 45 1;
createNode animCurveTU -n "front_right_visibility";
	rename -uid "8C043A21-4EEC-A14E-4630-2080E62968BA";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0 45 0;
	setAttr -s 12 ".kot[0:11]"  5 5 5 5 5 5 5 5 
		5 5 5 5;
createNode animCurveTA -n "front_right_rotateX";
	rename -uid "D6148975-42F7-2D26-5FAA-788F82033ED6";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 -70.958162292656453 5 31.185388956248577
		 10 0 12 0 14 0 16 0 20 0 25 0 30 0 35 0 40 0 45 0;
createNode animCurveTA -n "front_right_rotateY";
	rename -uid "8A67C274-43D8-E13A-CACC-4ABFA273CABD";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0 45 0;
createNode animCurveTA -n "front_right_rotateZ";
	rename -uid "4F664567-4E64-F62E-31D1-1D812BB73C1C";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0 40 0 45 0;
createNode animCurveTU -n "front_right_scaleX";
	rename -uid "F27229E0-402E-F37D-B4D9-F1AB2B0BC41E";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1 45 1;
createNode animCurveTU -n "front_right_scaleY";
	rename -uid "BCF524A4-41F7-52BF-33B3-15A3F36B1E89";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1 45 1;
createNode animCurveTU -n "front_right_scaleZ";
	rename -uid "F58A8448-46A5-5302-DF28-CEA37728D159";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 12 ".ktv[0:11]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1 40 1 45 1;
createNode animCurveTU -n "joint31_visibility";
	rename -uid "B3579481-4ED4-5003-4C62-EB82B192AC49";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 1 12 1 14 0 16 0 20 1 25 1 30 1
		 35 1;
	setAttr -s 10 ".kot[0:9]"  5 5 5 5 5 5 5 5 
		5 5;
createNode animCurveTA -n "joint31_rotateX";
	rename -uid "66C5DEA9-4B83-8525-D70B-C49F1BF58FC0";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 -12.976798417575095 10 -40.694561887114631
		 12 -48.826803342647118 14 -52.560818065268684 16 -67.088204947566595 20 -52.560818065268684
		 25 -52.560818065268684 30 -21.555334251542387 35 23.278972105825051;
createNode animCurveTA -n "joint31_rotateY";
	rename -uid "6ACD2C1B-46CF-826F-5A8D-0A9E49F34782";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0;
createNode animCurveTA -n "joint31_rotateZ";
	rename -uid "B711FE5F-4151-D6A5-9403-87AB4CCE650D";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 25 0 30 0
		 35 0;
createNode animCurveTU -n "joint31_scaleX";
	rename -uid "7EB7FBD4-41FD-08F7-65AA-86A575E47B44";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1;
createNode animCurveTU -n "joint31_scaleY";
	rename -uid "23C3EE45-429F-4D78-846B-67A6C83EA12D";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1;
createNode animCurveTU -n "joint31_scaleZ";
	rename -uid "66BF7BF5-44E2-C0BC-0D8D-55A606297368";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 10 ".ktv[0:9]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 25 1 30 1
		 35 1;
createNode animCurveTU -n "joint30_visibility";
	rename -uid "592A958C-4290-0381-00F8-70B9CF497A29";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 30 0 35 0;
	setAttr -s 9 ".kot[0:8]"  5 5 5 5 5 5 5 5 
		5;
createNode animCurveTA -n "joint30_rotateX";
	rename -uid "BFBD5E65-41F6-5C46-3B42-6CAED6A022D2";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 30 0 35 -32.095012201968068;
createNode animCurveTA -n "joint30_rotateY";
	rename -uid "0E18576B-47C3-3E73-B43A-2DB03B088827";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 30 0 35 0;
createNode animCurveTA -n "joint30_rotateZ";
	rename -uid "A172CD91-4D87-F7FE-FD5B-83A85FB98DC6";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 30 0 35 0;
createNode animCurveTU -n "joint30_scaleX";
	rename -uid "D8017FC1-41C8-AB97-92CF-318A422A4E61";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 30 1 35 1;
createNode animCurveTU -n "joint30_scaleY";
	rename -uid "27528121-4558-5089-41B7-62A57B5710C3";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 30 1 35 1;
createNode animCurveTU -n "joint30_scaleZ";
	rename -uid "752A6C6D-48D0-7CA3-B152-708243208273";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 30 1 35 1;
createNode animCurveTU -n "joint29_visibility";
	rename -uid "4E7F88C5-4DB3-1086-3EB8-B2AB57AAECCF";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 30 0 35 0;
	setAttr -s 9 ".kot[0:8]"  5 5 5 5 5 5 5 5 
		5;
createNode animCurveTA -n "joint29_rotateX";
	rename -uid "16B2CA7E-4BB4-6A23-0B54-7299A0D7919D";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 30 0 35 -13.21290768670632;
createNode animCurveTA -n "joint29_rotateY";
	rename -uid "DCFF8DFD-4F32-0EE2-37D1-D2BCEB6EEC7E";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 30 0 35 0;
createNode animCurveTA -n "joint29_rotateZ";
	rename -uid "E7683CAB-44E9-B1ED-AE6C-6D985D8F04A0";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 30 0 35 0;
createNode animCurveTU -n "joint29_scaleX";
	rename -uid "79318CFF-4299-FF12-94CA-99B747C37F15";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 30 1 35 1;
createNode animCurveTU -n "joint29_scaleY";
	rename -uid "4D2408EC-436C-5A71-AEE4-978A5EF8E281";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 30 1 35 1;
createNode animCurveTU -n "joint29_scaleZ";
	rename -uid "7FC365CC-4FC9-FDA5-CDE1-108DF9F57DFB";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 30 1 35 1;
createNode animCurveTU -n "joint28_visibility";
	rename -uid "5E729920-4F56-ACC8-0198-E181E63FE91D";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0 5 0 10 1 12 1 14 0 16 0 20 0 30 0 35 0;
	setAttr -s 9 ".kot[0:8]"  5 5 5 5 5 5 5 5 
		5;
createNode animCurveTA -n "joint28_rotateX";
	rename -uid "99782E2C-4C6D-0D5F-74DC-D08FDA14F9F3";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 30 0 35 0;
createNode animCurveTA -n "joint28_rotateY";
	rename -uid "CE30821D-44A3-6535-DBB1-5D94047863A9";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 30 0 35 0;
createNode animCurveTA -n "joint28_rotateZ";
	rename -uid "F2F05217-4A25-409A-FC21-5DA9051C801D";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 30 0 35 0;
createNode animCurveTU -n "joint28_scaleX";
	rename -uid "AC48C748-434E-2B9C-2CA7-2CA717BF41D2";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 30 1 35 1;
createNode animCurveTU -n "joint28_scaleY";
	rename -uid "BE4DE9B7-4D6D-79A1-5264-A3BB36782C88";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 30 1 35 1;
createNode animCurveTU -n "joint28_scaleZ";
	rename -uid "9C9350D1-4A26-E4B0-DD0F-4DBBBD8069E9";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 30 1 35 1;
createNode animCurveTU -n "right_visibility";
	rename -uid "A97260B3-408D-3DDE-75DC-36A2407B1907";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0 5 0 10 1 12 1 14 0 16 0 20 1 30 1 35 1;
	setAttr -s 9 ".kot[0:8]"  5 5 5 5 5 5 5 5 
		5;
createNode animCurveTA -n "right_rotateX";
	rename -uid "D96DD046-4733-D859-4889-77A26C955648";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 -80.213791864539402 5 -44.142940868142396
		 10 13.038502486710989 12 16.365198753708409 14 16.840440719047646 16 16.840440719047646
		 20 16.840440719047646 30 16.840440719047646 35 16.840440719047646;
createNode animCurveTA -n "right_rotateY";
	rename -uid "863EC854-4891-3639-27E4-3AAC3D2B82C3";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 30 0 35 0;
createNode animCurveTA -n "right_rotateZ";
	rename -uid "5D38A3D1-4256-C40A-4752-A1922A2BF3B5";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 0 5 0 10 0 12 0 14 0 16 0 20 0 30 0 35 0;
createNode animCurveTU -n "right_scaleX";
	rename -uid "4091DF1B-41B4-284B-7A21-32B9533A66D1";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 30 1 35 1;
createNode animCurveTU -n "right_scaleY";
	rename -uid "E46D7B15-4ECD-5C82-E2F3-6CA674457E00";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 30 1 35 1;
createNode animCurveTU -n "right_scaleZ";
	rename -uid "0C0001E7-4115-093D-ADC8-698DAFF2B821";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 9 ".ktv[0:8]"  1 1 5 1 10 1 12 1 14 1 16 1 20 1 30 1 35 1;
createNode shadingEngine -n "blinn1SG";
	rename -uid "E058AEB7-4C89-F7EA-5DAF-AE924E7BDECF";
	setAttr ".ihi" 0;
	setAttr ".fzn" yes;
	setAttr -s 3 ".dsm";
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo1";
	rename -uid "BF10F4D2-4E2E-2312-D80C-A1895D464AF6";
createNode file -n "file1";
	rename -uid "E8EA93D4-4121-1430-14E9-FF9221759FC3";
	setAttr ".fzn" yes;
	setAttr ".ftn" -type "string" "C:/Users/Anie/live_Projects/Games-Project/Assets/Textures/palette.png";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "place2dTexture1";
	rename -uid "50E18193-4B46-C88E-684C-65B5FA2AE6A3";
	setAttr ".fzn" yes;
createNode animCurveTU -n "middleKraken_visibility";
	rename -uid "D9C7F8F5-4D5E-A8D6-51E9-278A9CE9F725";
	setAttr ".tan" 9;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  1 0 5 0 10 0 12 0 14 0 16 0;
	setAttr -s 6 ".kot[0:5]"  5 5 5 5 5 5;
createNode animCurveTL -n "middleKraken_translateX";
	rename -uid "B7965067-4292-2893-8853-E3A31DF271ED";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  1 -0.0036793563601933421 5 -0.0036793563601933421
		 10 -0.0036793563601933421 12 -0.0036793563601933421 14 -0.0036793563601933421 16 -0.0036793563601933421;
createNode animCurveTL -n "middleKraken_translateY";
	rename -uid "060C17B2-4C29-BDDD-7385-908A05607AF6";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  1 -0.19610418872385593 5 -0.19610418872385593
		 10 -0.19610418872385593 12 -0.19610418872385593 14 -0.19610418872385593 16 -0.19610418872385593;
createNode animCurveTL -n "middleKraken_translateZ";
	rename -uid "D82CF718-43CB-3411-C0C1-1C9D965D9A7B";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  1 -0.12669608281380773 5 -0.12669608281380773
		 10 -0.12669608281380773 12 -0.12669608281380773 14 -0.12669608281380773 16 -0.12669608281380773;
createNode animCurveTA -n "middleKraken_rotateX";
	rename -uid "3920DE9D-49A7-2B15-015A-79AF86B35D85";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  1 0 5 0 10 0 12 0 14 0 16 0;
createNode animCurveTA -n "middleKraken_rotateY";
	rename -uid "E54DE160-4560-094D-0637-0C924AFA9E41";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  1 0 5 0 10 0 12 0 14 0 16 0;
createNode animCurveTA -n "middleKraken_rotateZ";
	rename -uid "AAB8A523-4693-D6CD-DD4B-8B9C8E8B3C1B";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  1 0 5 0 10 0 12 0 14 0 16 0;
createNode animCurveTU -n "middleKraken_scaleX";
	rename -uid "EEB98A52-43E4-20B7-01F5-4ABCD88BD913";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  1 1 5 1 10 1 12 1 14 1 16 1;
createNode animCurveTU -n "middleKraken_scaleY";
	rename -uid "F23B74E9-4532-B2D2-94D6-5684AFA49531";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  1 1 5 1 10 1 12 1 14 1 16 1;
createNode animCurveTU -n "middleKraken_scaleZ";
	rename -uid "4EA5F4FD-4D04-198C-2B57-5D830F8338B0";
	setAttr ".tan" 18;
	setAttr ".wgt" no;
	setAttr -s 6 ".ktv[0:5]"  1 1 5 1 10 1 12 1 14 1 16 1;
createNode groupId -n "pasted__groupId5";
	rename -uid "38B0A0E2-49A4-7BBE-CF19-3BB81AEDCAB5";
	setAttr ".ihi" 0;
createNode groupId -n "pasted__groupId10";
	rename -uid "F86FFE4F-4D4A-D542-6977-8DBAE1B55140";
	setAttr ".ihi" 0;
createNode blinn -n "pasted__blinn1";
	rename -uid "A932A070-4725-BFB5-B722-A8B9ADE4BE44";
createNode shadingEngine -n "pasted__blinn1SG";
	rename -uid "EF7ACDD1-424B-752D-0AB6-B0BF92B0094B";
	setAttr ".ihi" 0;
	setAttr ".fzn" yes;
	setAttr ".ro" yes;
createNode materialInfo -n "pasted__materialInfo1";
	rename -uid "AB1FA88D-4D94-52F0-8BB4-E8B80901858B";
createNode file -n "pasted__file1";
	rename -uid "ACEC1FE6-46B9-14DB-2180-ADB5C5CE8789";
	setAttr ".fzn" yes;
	setAttr ".ftn" -type "string" "C:/Users/Anie/live_Projects/Games-Project/Assets/Textures/palette.png";
	setAttr ".cs" -type "string" "sRGB";
createNode place2dTexture -n "pasted__place2dTexture1";
	rename -uid "8AB5E43D-492F-1393-7649-E7B607D0FD4E";
	setAttr ".fzn" yes;
createNode nodeGraphEditorInfo -n "pasted__hyperShadePrimaryNodeEditorSavedTabsInfo";
	rename -uid "F8E4380B-4C1E-DC08-FEC6-9BA762F12794";
	setAttr ".tgi[0].tn" -type "string" "Untitled_1";
	setAttr ".tgi[0].vl" -type "double2" -124.52492164620132 -595.36215662081531 ;
	setAttr ".tgi[0].vh" -type "double2" 1114.5954837662889 226.73508438573555 ;
	setAttr -s 4 ".tgi[0].ni";
	setAttr ".tgi[0].ni[0].x" 524.28570556640625;
	setAttr ".tgi[0].ni[0].y" -1.4285714626312256;
	setAttr ".tgi[0].ni[0].nvs" 1923;
	setAttr ".tgi[0].ni[1].x" 1.4285714626312256;
	setAttr ".tgi[0].ni[1].y" -137.14285278320312;
	setAttr ".tgi[0].ni[1].nvs" 1923;
	setAttr ".tgi[0].ni[2].x" 785.71429443359375;
	setAttr ".tgi[0].ni[2].y" -114.28571319580078;
	setAttr ".tgi[0].ni[2].nvs" 1923;
	setAttr ".tgi[0].ni[3].x" 262.85714721679687;
	setAttr ".tgi[0].ni[3].y" -114.28571319580078;
	setAttr ".tgi[0].ni[3].nvs" 1923;
createNode blinn -n "main_colour";
	rename -uid "AA2C1882-473A-224F-68E1-E5BF22E39C91";
	setAttr ".c" -type "float3" 0.1187 0 0.2375 ;
createNode shadingEngine -n "blinn2SG";
	rename -uid "A7368ED4-460B-51D2-AA65-208BD5045E3E";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo2";
	rename -uid "DF970C3E-4B78-821F-DFE2-19B692BE42E9";
createNode blinn -n "blinn1";
	rename -uid "B4C825CC-4A27-CDA8-3FDA-F7B0855AED57";
createNode blinn -n "eyecolour";
	rename -uid "39AF413D-4A40-62D4-19EE-FD9681B53E9A";
	setAttr ".c" -type "float3" 0.94129997 1 0.1029 ;
createNode shadingEngine -n "blinn3SG";
	rename -uid "0C137487-47C8-5F4D-CEA8-A89961794BF2";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo3";
	rename -uid "97CC27FE-45AD-EE3E-0C34-6CAFDC58D037";
createNode groupParts -n "groupParts3";
	rename -uid "D55CCCD0-4D3F-A8E3-F3D2-18B8906F1C85";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 18 "f[2:3]" "f[6:7]" "f[11:12]" "f[21]" "f[35:39]" "f[46:48]" "f[50:52]" "f[56:59]" "f[66:67]" "f[69:75]" "f[78:137]" "f[139]" "f[142:154]" "f[157:159]" "f[161:162]" "f[166:201]" "f[203:204]" "f[207:237]";
	setAttr ".irc" -type "componentList" 19 "f[0:1]" "f[4:5]" "f[8:10]" "f[13:20]" "f[22:34]" "f[40:45]" "f[49]" "f[53:55]" "f[60:65]" "f[68]" "f[76:77]" "f[138]" "f[140:141]" "f[155:156]" "f[160]" "f[163:165]" "f[202]" "f[205:206]" "f[238:249]";
	setAttr ".gi" 65;
createNode groupParts -n "groupParts4";
	rename -uid "3A3E6257-4EDE-ACFC-4BED-6096C075F131";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 4 "f[239]" "f[241]" "f[243]" "f[245]";
	setAttr ".gi" 67;
createNode blinn -n "middle_eye";
	rename -uid "6F77CABF-48C1-BE27-3BA0-A099E96922F4";
	setAttr ".c" -type "float3" 0.122 0.122 0.122 ;
createNode shadingEngine -n "blinn4SG";
	rename -uid "EE08379E-464A-E251-2997-4396BD00DCEB";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo4";
	rename -uid "85C961E1-4176-7866-8D52-D18DAD32CA31";
createNode groupParts -n "groupParts5";
	rename -uid "344965F5-4691-3B79-8794-5887A82232DE";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 4 "f[238]" "f[240]" "f[242]" "f[244]";
	setAttr ".gi" 68;
createNode blinn -n "bottom_eye";
	rename -uid "3AE041CF-496C-90EB-D485-5384E69500A4";
	setAttr ".c" -type "float3" 0.54000002 0.4991 0.1058 ;
createNode shadingEngine -n "blinn5SG";
	rename -uid "5DAC4F33-42E5-3EB7-81D4-D98FFF1815CC";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo5";
	rename -uid "1C3E17BB-4C81-7F26-BE26-A4B11E2D9F6C";
createNode groupParts -n "groupParts6";
	rename -uid "6124C88C-4628-6443-1C29-6089D5902735";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 2 "f[26:28]" "f[55]";
	setAttr ".gi" 69;
createNode blinn -n "krekenhead";
	rename -uid "FDF43581-4EFE-6C28-6F1C-BA81D00DCD08";
	setAttr ".c" -type "float3" 0.068400003 0.0076000001 0.1293 ;
createNode shadingEngine -n "blinn6SG";
	rename -uid "2DE15D8C-44FD-B020-D953-B6B111704632";
	setAttr ".ihi" 0;
	setAttr ".ro" yes;
createNode materialInfo -n "materialInfo6";
	rename -uid "F3DC6F61-4605-A194-7E6B-3ABE13D9A172";
createNode groupParts -n "groupParts7";
	rename -uid "81711D0E-423E-124F-614A-D5A3CAB1DD8C";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 20 "f[0:1]" "f[4:5]" "f[8:10]" "f[13:20]" "f[22:25]" "f[29:34]" "f[40:45]" "f[49]" "f[53:54]" "f[60:65]" "f[68]" "f[76:77]" "f[138]" "f[140:141]" "f[155:156]" "f[160]" "f[163:165]" "f[202]" "f[205:206]" "f[246:249]";
	setAttr ".gi" 70;
createNode nodeGraphEditorInfo -n "hyperShadePrimaryNodeEditorSavedTabsInfo";
	rename -uid "A26186B0-42BB-84FC-0148-798459B056F6";
	setAttr ".tgi[0].tn" -type "string" "Untitled_1";
	setAttr ".tgi[0].vl" -type "double2" -233.40520590974711 -848.52574828410252 ;
	setAttr ".tgi[0].vh" -type "double2" 1473.3495593506821 283.82456849427274 ;
	setAttr -s 14 ".tgi[0].ni";
	setAttr ".tgi[0].ni[0].x" -52.884742736816406;
	setAttr ".tgi[0].ni[0].y" 38.963951110839844;
	setAttr ".tgi[0].ni[0].nvs" 1923;
	setAttr ".tgi[0].ni[1].x" 785.71429443359375;
	setAttr ".tgi[0].ni[1].y" -114.28571319580078;
	setAttr ".tgi[0].ni[1].nvs" 1923;
	setAttr ".tgi[0].ni[2].x" 236.52340698242187;
	setAttr ".tgi[0].ni[2].y" 2.5702049732208252;
	setAttr ".tgi[0].ni[2].nvs" 1923;
	setAttr ".tgi[0].ni[3].x" 1.4285714626312256;
	setAttr ".tgi[0].ni[3].y" -150;
	setAttr ".tgi[0].ni[3].nvs" 1923;
	setAttr ".tgi[0].ni[4].x" 262.85714721679687;
	setAttr ".tgi[0].ni[4].y" -258.57144165039062;
	setAttr ".tgi[0].ni[4].nvs" 1923;
	setAttr ".tgi[0].ni[5].x" 524.28570556640625;
	setAttr ".tgi[0].ni[5].y" -1.4285714626312256;
	setAttr ".tgi[0].ni[5].nvs" 1923;
	setAttr ".tgi[0].ni[6].x" 1.4285714626312256;
	setAttr ".tgi[0].ni[6].y" -1.4285714626312256;
	setAttr ".tgi[0].ni[6].nvs" 1923;
	setAttr ".tgi[0].ni[7].x" 262.85714721679687;
	setAttr ".tgi[0].ni[7].y" -118.57142639160156;
	setAttr ".tgi[0].ni[7].nvs" 1923;
	setAttr ".tgi[0].ni[8].x" 1.4285714626312256;
	setAttr ".tgi[0].ni[8].y" -457.14285278320312;
	setAttr ".tgi[0].ni[8].nvs" 1923;
	setAttr ".tgi[0].ni[9].x" 262.85714721679687;
	setAttr ".tgi[0].ni[9].y" -565.71429443359375;
	setAttr ".tgi[0].ni[9].nvs" 1923;
	setAttr ".tgi[0].ni[10].x" 1.4285714626312256;
	setAttr ".tgi[0].ni[10].y" -11.428571701049805;
	setAttr ".tgi[0].ni[10].nvs" 1923;
	setAttr ".tgi[0].ni[11].x" 262.85714721679687;
	setAttr ".tgi[0].ni[11].y" -124.28571319580078;
	setAttr ".tgi[0].ni[11].nvs" 1923;
	setAttr ".tgi[0].ni[12].x" 598.5714111328125;
	setAttr ".tgi[0].ni[12].y" -1.4285714626312256;
	setAttr ".tgi[0].ni[12].nvs" 1923;
	setAttr ".tgi[0].ni[13].x" 860;
	setAttr ".tgi[0].ni[13].y" -118.57142639160156;
	setAttr ".tgi[0].ni[13].nvs" 1923;
createNode groupParts -n "groupParts8";
	rename -uid "CA002AC1-403F-60FC-3354-CB82EF7A814A";
	setAttr ".ihi" 0;
	setAttr ".irc" -type "componentList" 18 "f[2:3]" "f[6:7]" "f[11:12]" "f[21]" "f[35:39]" "f[46:48]" "f[50:52]" "f[56:59]" "f[66:67]" "f[69:75]" "f[78:137]" "f[139]" "f[142:154]" "f[157:159]" "f[161:162]" "f[166:201]" "f[203:204]" "f[207:237]";
	setAttr ".gi" 65;
createNode groupParts -n "groupParts9";
	rename -uid "C45E3242-4BF0-B91E-A2C8-6D9123D222A0";
	setAttr ".ihi" 0;
	setAttr ".irc" -type "componentList" 4 "f[239]" "f[241]" "f[243]" "f[245]";
	setAttr ".gi" 67;
createNode groupParts -n "groupParts10";
	rename -uid "6DC9E667-4359-C5D7-A085-9990820267F7";
	setAttr ".ihi" 0;
	setAttr ".irc" -type "componentList" 4 "f[238]" "f[240]" "f[242]" "f[244]";
	setAttr ".gi" 68;
createNode groupParts -n "groupParts11";
	rename -uid "77DE7C45-42EE-B5B2-7883-8288850116A6";
	setAttr ".ihi" 0;
	setAttr ".irc" -type "componentList" 2 "f[26:28]" "f[55]";
	setAttr ".gi" 69;
createNode groupParts -n "groupParts12";
	rename -uid "2E96F604-430C-05E3-CB61-2F8B4188C401";
	setAttr ".ihi" 0;
	setAttr ".irc" -type "componentList" 20 "f[0:1]" "f[4:5]" "f[8:10]" "f[13:20]" "f[22:25]" "f[29:34]" "f[40:45]" "f[49]" "f[53:54]" "f[60:65]" "f[68]" "f[76:77]" "f[138]" "f[140:141]" "f[155:156]" "f[160]" "f[163:165]" "f[202]" "f[205:206]" "f[246:249]";
	setAttr ".gi" 70;
createNode groupId -n "groupId13";
	rename -uid "4A997ACB-4328-B9E6-7E40-55AE93F2BDE2";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts13";
	rename -uid "62386AF6-4BEA-41BC-F28E-4880F1D8914F";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 18 "f[2:3]" "f[6:7]" "f[11:12]" "f[21]" "f[35:39]" "f[46:48]" "f[50:52]" "f[56:59]" "f[66:67]" "f[69:75]" "f[78:137]" "f[139]" "f[142:154]" "f[157:159]" "f[161:162]" "f[166:201]" "f[203:204]" "f[207:237]";
createNode groupId -n "groupId14";
	rename -uid "8B9AB466-446B-3966-A96A-20BD406EE222";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts14";
	rename -uid "02C148B2-451B-9571-7D2C-3F91E2182AC9";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 4 "f[239]" "f[241]" "f[243]" "f[245]";
createNode groupId -n "groupId15";
	rename -uid "D8F693AE-4B68-C8A8-01F1-AC981B4F82BB";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts15";
	rename -uid "D343F472-4B10-2D3F-3FA0-6B891CCD4FA0";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 4 "f[238]" "f[240]" "f[242]" "f[244]";
createNode groupId -n "groupId16";
	rename -uid "FC47F28A-4D94-23DA-AECD-1C933DA7144F";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts16";
	rename -uid "822B5393-47D2-914A-F2EE-2AA091A5F7F4";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 2 "f[26:28]" "f[55]";
createNode groupId -n "groupId17";
	rename -uid "50F99C1F-4819-1B1E-1A60-65932E0212D8";
	setAttr ".ihi" 0;
createNode groupParts -n "groupParts17";
	rename -uid "C89390FF-4AD3-6532-4457-96821DC6F283";
	setAttr ".ihi" 0;
	setAttr ".ic" -type "componentList" 20 "f[0:1]" "f[4:5]" "f[8:10]" "f[13:20]" "f[22:25]" "f[29:34]" "f[40:45]" "f[49]" "f[53:54]" "f[60:65]" "f[68]" "f[76:77]" "f[138]" "f[140:141]" "f[155:156]" "f[160]" "f[163:165]" "f[202]" "f[205:206]" "f[246:249]";
select -ne :time1;
	setAttr ".o" 76;
	setAttr ".unw" 76;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 9 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 11 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderUtilityList1;
	setAttr -s 2 ".u";
select -ne :defaultRenderingList1;
select -ne :defaultTextureList1;
	setAttr -s 2 ".tx";
select -ne :initialShadingGroup;
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "kraken_visibility.o" "kraken.v";
connectAttr "groupId12.id" "krakenShape.iog.og[3].gid";
connectAttr "tweakSet1.mwc" "krakenShape.iog.og[3].gco";
connectAttr "skinCluster1GroupId.id" "krakenShape.iog.og[4].gid";
connectAttr "skinCluster1Set.mwc" "krakenShape.iog.og[4].gco";
connectAttr "groupId13.id" "krakenShape.iog.og[5].gid";
connectAttr "blinn2SG.mwc" "krakenShape.iog.og[5].gco";
connectAttr "groupId14.id" "krakenShape.iog.og[6].gid";
connectAttr "blinn3SG.mwc" "krakenShape.iog.og[6].gco";
connectAttr "groupId15.id" "krakenShape.iog.og[7].gid";
connectAttr "blinn4SG.mwc" "krakenShape.iog.og[7].gco";
connectAttr "groupId16.id" "krakenShape.iog.og[8].gid";
connectAttr "blinn5SG.mwc" "krakenShape.iog.og[8].gco";
connectAttr "groupId17.id" "krakenShape.iog.og[9].gid";
connectAttr "blinn6SG.mwc" "krakenShape.iog.og[9].gco";
connectAttr "groupParts17.og" "krakenShape.i";
connectAttr "tweak1.vl[0].vt[0]" "krakenShape.twl";
connectAttr "middleKraken_visibility.o" "middleKraken.v";
connectAttr "middleKraken_translateX.o" "middleKraken.tx";
connectAttr "middleKraken_translateY.o" "middleKraken.ty";
connectAttr "middleKraken_translateZ.o" "middleKraken.tz";
connectAttr "middleKraken_rotateX.o" "middleKraken.rx";
connectAttr "middleKraken_rotateY.o" "middleKraken.ry";
connectAttr "middleKraken_rotateZ.o" "middleKraken.rz";
connectAttr "middleKraken_scaleX.o" "middleKraken.sx";
connectAttr "middleKraken_scaleY.o" "middleKraken.sy";
connectAttr "middleKraken_scaleZ.o" "middleKraken.sz";
connectAttr "middleKraken.s" "right.is";
connectAttr "right_scaleX.o" "right.sx";
connectAttr "right_scaleY.o" "right.sy";
connectAttr "right_scaleZ.o" "right.sz";
connectAttr "right_translateX.o" "right.tx";
connectAttr "right_translateY.o" "right.ty";
connectAttr "right_translateZ.o" "right.tz";
connectAttr "right_visibility.o" "right.v";
connectAttr "right_rotateX.o" "right.rx";
connectAttr "right_rotateY.o" "right.ry";
connectAttr "right_rotateZ.o" "right.rz";
connectAttr "joint28_scaleX.o" "joint28.sx";
connectAttr "joint28_scaleY.o" "joint28.sy";
connectAttr "joint28_scaleZ.o" "joint28.sz";
connectAttr "right.s" "joint28.is";
connectAttr "joint28_translateX.o" "joint28.tx";
connectAttr "joint28_translateY.o" "joint28.ty";
connectAttr "joint28_translateZ.o" "joint28.tz";
connectAttr "joint28_visibility.o" "joint28.v";
connectAttr "joint28_rotateX.o" "joint28.rx";
connectAttr "joint28_rotateY.o" "joint28.ry";
connectAttr "joint28_rotateZ.o" "joint28.rz";
connectAttr "joint29_scaleX.o" "joint29.sx";
connectAttr "joint29_scaleY.o" "joint29.sy";
connectAttr "joint29_scaleZ.o" "joint29.sz";
connectAttr "joint28.s" "joint29.is";
connectAttr "joint29_translateX.o" "joint29.tx";
connectAttr "joint29_translateY.o" "joint29.ty";
connectAttr "joint29_translateZ.o" "joint29.tz";
connectAttr "joint29_visibility.o" "joint29.v";
connectAttr "joint29_rotateX.o" "joint29.rx";
connectAttr "joint29_rotateY.o" "joint29.ry";
connectAttr "joint29_rotateZ.o" "joint29.rz";
connectAttr "joint30_scaleX.o" "joint30.sx";
connectAttr "joint30_scaleY.o" "joint30.sy";
connectAttr "joint30_scaleZ.o" "joint30.sz";
connectAttr "joint29.s" "joint30.is";
connectAttr "joint30_translateX.o" "joint30.tx";
connectAttr "joint30_translateY.o" "joint30.ty";
connectAttr "joint30_translateZ.o" "joint30.tz";
connectAttr "joint30_visibility.o" "joint30.v";
connectAttr "joint30_rotateX.o" "joint30.rx";
connectAttr "joint30_rotateY.o" "joint30.ry";
connectAttr "joint30_rotateZ.o" "joint30.rz";
connectAttr "joint31_scaleX.o" "joint31.sx";
connectAttr "joint31_scaleY.o" "joint31.sy";
connectAttr "joint31_scaleZ.o" "joint31.sz";
connectAttr "joint30.s" "joint31.is";
connectAttr "joint31_translateX.o" "joint31.tx";
connectAttr "joint31_translateY.o" "joint31.ty";
connectAttr "joint31_translateZ.o" "joint31.tz";
connectAttr "joint31_visibility.o" "joint31.v";
connectAttr "joint31_rotateX.o" "joint31.rx";
connectAttr "joint31_rotateY.o" "joint31.ry";
connectAttr "joint31_rotateZ.o" "joint31.rz";
connectAttr "joint32_translateX.o" "joint32.tx";
connectAttr "joint32_translateY.o" "joint32.ty";
connectAttr "joint32_translateZ.o" "joint32.tz";
connectAttr "joint31.s" "joint32.is";
connectAttr "joint32_visibility.o" "joint32.v";
connectAttr "joint32_rotateX.o" "joint32.rx";
connectAttr "joint32_rotateY.o" "joint32.ry";
connectAttr "joint32_rotateZ.o" "joint32.rz";
connectAttr "joint32_scaleX.o" "joint32.sx";
connectAttr "joint32_scaleY.o" "joint32.sy";
connectAttr "joint32_scaleZ.o" "joint32.sz";
connectAttr "middleKraken.s" "front_right.is";
connectAttr "front_right_scaleX.o" "front_right.sx";
connectAttr "front_right_scaleY.o" "front_right.sy";
connectAttr "front_right_scaleZ.o" "front_right.sz";
connectAttr "front_right_translateX.o" "front_right.tx";
connectAttr "front_right_translateY.o" "front_right.ty";
connectAttr "front_right_translateZ.o" "front_right.tz";
connectAttr "front_right_visibility.o" "front_right.v";
connectAttr "front_right_rotateX.o" "front_right.rx";
connectAttr "front_right_rotateY.o" "front_right.ry";
connectAttr "front_right_rotateZ.o" "front_right.rz";
connectAttr "joint1_scaleX.o" "joint1.sx";
connectAttr "joint1_scaleY.o" "joint1.sy";
connectAttr "joint1_scaleZ.o" "joint1.sz";
connectAttr "front_right.s" "joint1.is";
connectAttr "joint1_translateX.o" "joint1.tx";
connectAttr "joint1_translateY.o" "joint1.ty";
connectAttr "joint1_translateZ.o" "joint1.tz";
connectAttr "joint1_visibility.o" "joint1.v";
connectAttr "joint1_rotateX.o" "joint1.rx";
connectAttr "joint1_rotateY.o" "joint1.ry";
connectAttr "joint1_rotateZ.o" "joint1.rz";
connectAttr "joint2_scaleX.o" "joint2.sx";
connectAttr "joint2_scaleY.o" "joint2.sy";
connectAttr "joint2_scaleZ.o" "joint2.sz";
connectAttr "joint1.s" "joint2.is";
connectAttr "joint2_translateX.o" "joint2.tx";
connectAttr "joint2_translateY.o" "joint2.ty";
connectAttr "joint2_translateZ.o" "joint2.tz";
connectAttr "joint2_visibility.o" "joint2.v";
connectAttr "joint2_rotateX.o" "joint2.rx";
connectAttr "joint2_rotateY.o" "joint2.ry";
connectAttr "joint2_rotateZ.o" "joint2.rz";
connectAttr "joint3_scaleX.o" "joint3.sx";
connectAttr "joint3_scaleY.o" "joint3.sy";
connectAttr "joint3_scaleZ.o" "joint3.sz";
connectAttr "joint2.s" "joint3.is";
connectAttr "joint3_translateX.o" "joint3.tx";
connectAttr "joint3_translateY.o" "joint3.ty";
connectAttr "joint3_translateZ.o" "joint3.tz";
connectAttr "joint3_visibility.o" "joint3.v";
connectAttr "joint3_rotateX.o" "joint3.rx";
connectAttr "joint3_rotateY.o" "joint3.ry";
connectAttr "joint3_rotateZ.o" "joint3.rz";
connectAttr "joint4_scaleX.o" "joint4.sx";
connectAttr "joint4_scaleY.o" "joint4.sy";
connectAttr "joint4_scaleZ.o" "joint4.sz";
connectAttr "joint3.s" "joint4.is";
connectAttr "joint4_translateX.o" "joint4.tx";
connectAttr "joint4_translateY.o" "joint4.ty";
connectAttr "joint4_translateZ.o" "joint4.tz";
connectAttr "joint4_visibility.o" "joint4.v";
connectAttr "joint4_rotateX.o" "joint4.rx";
connectAttr "joint4_rotateY.o" "joint4.ry";
connectAttr "joint4_rotateZ.o" "joint4.rz";
connectAttr "joint4.s" "joint5.is";
connectAttr "joint5_translateX.o" "joint5.tx";
connectAttr "joint5_translateY.o" "joint5.ty";
connectAttr "joint5_translateZ.o" "joint5.tz";
connectAttr "joint5_visibility.o" "joint5.v";
connectAttr "joint5_rotateX.o" "joint5.rx";
connectAttr "joint5_rotateY.o" "joint5.ry";
connectAttr "joint5_rotateZ.o" "joint5.rz";
connectAttr "joint5_scaleX.o" "joint5.sx";
connectAttr "joint5_scaleY.o" "joint5.sy";
connectAttr "joint5_scaleZ.o" "joint5.sz";
connectAttr "middleKraken.s" "front_left.is";
connectAttr "front_left_scaleX.o" "front_left.sx";
connectAttr "front_left_scaleY.o" "front_left.sy";
connectAttr "front_left_scaleZ.o" "front_left.sz";
connectAttr "front_left_translateX.o" "front_left.tx";
connectAttr "front_left_translateY.o" "front_left.ty";
connectAttr "front_left_translateZ.o" "front_left.tz";
connectAttr "front_left_visibility.o" "front_left.v";
connectAttr "front_left_rotateX.o" "front_left.rx";
connectAttr "front_left_rotateY.o" "front_left.ry";
connectAttr "front_left_rotateZ.o" "front_left.rz";
connectAttr "joint6_scaleX.o" "joint6.sx";
connectAttr "joint6_scaleY.o" "joint6.sy";
connectAttr "joint6_scaleZ.o" "joint6.sz";
connectAttr "front_left.s" "joint6.is";
connectAttr "joint6_translateX.o" "joint6.tx";
connectAttr "joint6_translateY.o" "joint6.ty";
connectAttr "joint6_translateZ.o" "joint6.tz";
connectAttr "joint6_visibility.o" "joint6.v";
connectAttr "joint6_rotateX.o" "joint6.rx";
connectAttr "joint6_rotateY.o" "joint6.ry";
connectAttr "joint6_rotateZ.o" "joint6.rz";
connectAttr "joint7_scaleX.o" "joint7.sx";
connectAttr "joint7_scaleY.o" "joint7.sy";
connectAttr "joint7_scaleZ.o" "joint7.sz";
connectAttr "joint6.s" "joint7.is";
connectAttr "joint7_translateX.o" "joint7.tx";
connectAttr "joint7_translateY.o" "joint7.ty";
connectAttr "joint7_translateZ.o" "joint7.tz";
connectAttr "joint7_visibility.o" "joint7.v";
connectAttr "joint7_rotateX.o" "joint7.rx";
connectAttr "joint7_rotateY.o" "joint7.ry";
connectAttr "joint7_rotateZ.o" "joint7.rz";
connectAttr "joint8_translateX.o" "joint8.tx";
connectAttr "joint8_translateY.o" "joint8.ty";
connectAttr "joint8_translateZ.o" "joint8.tz";
connectAttr "joint8_scaleX.o" "joint8.sx";
connectAttr "joint8_scaleY.o" "joint8.sy";
connectAttr "joint8_scaleZ.o" "joint8.sz";
connectAttr "joint7.s" "joint8.is";
connectAttr "joint8_visibility.o" "joint8.v";
connectAttr "joint8_rotateX.o" "joint8.rx";
connectAttr "joint8_rotateY.o" "joint8.ry";
connectAttr "joint8_rotateZ.o" "joint8.rz";
connectAttr "joint9_translateX.o" "joint9.tx";
connectAttr "joint9_translateY.o" "joint9.ty";
connectAttr "joint9_translateZ.o" "joint9.tz";
connectAttr "joint9_scaleX.o" "joint9.sx";
connectAttr "joint9_scaleY.o" "joint9.sy";
connectAttr "joint9_scaleZ.o" "joint9.sz";
connectAttr "joint8.s" "joint9.is";
connectAttr "joint9_visibility.o" "joint9.v";
connectAttr "joint9_rotateX.o" "joint9.rx";
connectAttr "joint9_rotateY.o" "joint9.ry";
connectAttr "joint9_rotateZ.o" "joint9.rz";
connectAttr "joint9.s" "joint10.is";
connectAttr "joint10_translateX.o" "joint10.tx";
connectAttr "joint10_translateY.o" "joint10.ty";
connectAttr "joint10_translateZ.o" "joint10.tz";
connectAttr "joint10_visibility.o" "joint10.v";
connectAttr "joint10_rotateX.o" "joint10.rx";
connectAttr "joint10_rotateY.o" "joint10.ry";
connectAttr "joint10_rotateZ.o" "joint10.rz";
connectAttr "joint10_scaleX.o" "joint10.sx";
connectAttr "joint10_scaleY.o" "joint10.sy";
connectAttr "joint10_scaleZ.o" "joint10.sz";
connectAttr "middleKraken.s" "left.is";
connectAttr "left_scaleX.o" "left.sx";
connectAttr "left_scaleY.o" "left.sy";
connectAttr "left_scaleZ.o" "left.sz";
connectAttr "left_translateX.o" "left.tx";
connectAttr "left_translateY.o" "left.ty";
connectAttr "left_translateZ.o" "left.tz";
connectAttr "left_visibility.o" "left.v";
connectAttr "left_rotateX.o" "left.rx";
connectAttr "left_rotateY.o" "left.ry";
connectAttr "left_rotateZ.o" "left.rz";
connectAttr "joint11_scaleX.o" "joint11.sx";
connectAttr "joint11_scaleY.o" "joint11.sy";
connectAttr "joint11_scaleZ.o" "joint11.sz";
connectAttr "left.s" "joint11.is";
connectAttr "joint11_translateX.o" "joint11.tx";
connectAttr "joint11_translateY.o" "joint11.ty";
connectAttr "joint11_translateZ.o" "joint11.tz";
connectAttr "joint11_visibility.o" "joint11.v";
connectAttr "joint11_rotateX.o" "joint11.rx";
connectAttr "joint11_rotateY.o" "joint11.ry";
connectAttr "joint11_rotateZ.o" "joint11.rz";
connectAttr "joint12_scaleX.o" "joint12.sx";
connectAttr "joint12_scaleY.o" "joint12.sy";
connectAttr "joint12_scaleZ.o" "joint12.sz";
connectAttr "joint11.s" "joint12.is";
connectAttr "joint12_translateX.o" "joint12.tx";
connectAttr "joint12_translateY.o" "joint12.ty";
connectAttr "joint12_translateZ.o" "joint12.tz";
connectAttr "joint12_visibility.o" "joint12.v";
connectAttr "joint12_rotateX.o" "joint12.rx";
connectAttr "joint12_rotateY.o" "joint12.ry";
connectAttr "joint12_rotateZ.o" "joint12.rz";
connectAttr "joint13_scaleX.o" "joint13.sx";
connectAttr "joint13_scaleY.o" "joint13.sy";
connectAttr "joint13_scaleZ.o" "joint13.sz";
connectAttr "joint12.s" "joint13.is";
connectAttr "joint13_translateX.o" "joint13.tx";
connectAttr "joint13_translateY.o" "joint13.ty";
connectAttr "joint13_translateZ.o" "joint13.tz";
connectAttr "joint13_visibility.o" "joint13.v";
connectAttr "joint13_rotateX.o" "joint13.rx";
connectAttr "joint13_rotateY.o" "joint13.ry";
connectAttr "joint13_rotateZ.o" "joint13.rz";
connectAttr "joint14_scaleX.o" "joint14.sx";
connectAttr "joint14_scaleY.o" "joint14.sy";
connectAttr "joint14_scaleZ.o" "joint14.sz";
connectAttr "joint13.s" "joint14.is";
connectAttr "joint14_translateX.o" "joint14.tx";
connectAttr "joint14_translateY.o" "joint14.ty";
connectAttr "joint14_translateZ.o" "joint14.tz";
connectAttr "joint14_visibility.o" "joint14.v";
connectAttr "joint14_rotateX.o" "joint14.rx";
connectAttr "joint14_rotateY.o" "joint14.ry";
connectAttr "joint14_rotateZ.o" "joint14.rz";
connectAttr "joint14.s" "joint15.is";
connectAttr "joint15_translateX.o" "joint15.tx";
connectAttr "joint15_translateY.o" "joint15.ty";
connectAttr "joint15_translateZ.o" "joint15.tz";
connectAttr "joint15_visibility.o" "joint15.v";
connectAttr "joint15_rotateX.o" "joint15.rx";
connectAttr "joint15_rotateY.o" "joint15.ry";
connectAttr "joint15_rotateZ.o" "joint15.rz";
connectAttr "joint15_scaleX.o" "joint15.sx";
connectAttr "joint15_scaleY.o" "joint15.sy";
connectAttr "joint15_scaleZ.o" "joint15.sz";
connectAttr "middleKraken.s" "back_left.is";
connectAttr "back_left_scaleX.o" "back_left.sx";
connectAttr "back_left_scaleY.o" "back_left.sy";
connectAttr "back_left_scaleZ.o" "back_left.sz";
connectAttr "back_left_translateX.o" "back_left.tx";
connectAttr "back_left_translateY.o" "back_left.ty";
connectAttr "back_left_translateZ.o" "back_left.tz";
connectAttr "back_left_visibility.o" "back_left.v";
connectAttr "back_left_rotateX.o" "back_left.rx";
connectAttr "back_left_rotateY.o" "back_left.ry";
connectAttr "back_left_rotateZ.o" "back_left.rz";
connectAttr "joint16_scaleX.o" "joint16.sx";
connectAttr "joint16_scaleY.o" "joint16.sy";
connectAttr "joint16_scaleZ.o" "joint16.sz";
connectAttr "back_left.s" "joint16.is";
connectAttr "joint16_translateX.o" "joint16.tx";
connectAttr "joint16_translateY.o" "joint16.ty";
connectAttr "joint16_translateZ.o" "joint16.tz";
connectAttr "joint16_visibility.o" "joint16.v";
connectAttr "joint16_rotateX.o" "joint16.rx";
connectAttr "joint16_rotateY.o" "joint16.ry";
connectAttr "joint16_rotateZ.o" "joint16.rz";
connectAttr "joint17_scaleX.o" "joint17.sx";
connectAttr "joint17_scaleY.o" "joint17.sy";
connectAttr "joint17_scaleZ.o" "joint17.sz";
connectAttr "joint16.s" "joint17.is";
connectAttr "joint17_translateX.o" "joint17.tx";
connectAttr "joint17_translateY.o" "joint17.ty";
connectAttr "joint17_translateZ.o" "joint17.tz";
connectAttr "joint17_visibility.o" "joint17.v";
connectAttr "joint17_rotateX.o" "joint17.rx";
connectAttr "joint17_rotateY.o" "joint17.ry";
connectAttr "joint17_rotateZ.o" "joint17.rz";
connectAttr "joint18_scaleX.o" "joint18.sx";
connectAttr "joint18_scaleY.o" "joint18.sy";
connectAttr "joint18_scaleZ.o" "joint18.sz";
connectAttr "joint17.s" "joint18.is";
connectAttr "joint18_translateX.o" "joint18.tx";
connectAttr "joint18_translateY.o" "joint18.ty";
connectAttr "joint18_translateZ.o" "joint18.tz";
connectAttr "joint18_visibility.o" "joint18.v";
connectAttr "joint18_rotateX.o" "joint18.rx";
connectAttr "joint18_rotateY.o" "joint18.ry";
connectAttr "joint18_rotateZ.o" "joint18.rz";
connectAttr "joint19_scaleX.o" "joint19.sx";
connectAttr "joint19_scaleY.o" "joint19.sy";
connectAttr "joint19_scaleZ.o" "joint19.sz";
connectAttr "joint18.s" "joint19.is";
connectAttr "joint19_translateX.o" "joint19.tx";
connectAttr "joint19_translateY.o" "joint19.ty";
connectAttr "joint19_translateZ.o" "joint19.tz";
connectAttr "joint19_visibility.o" "joint19.v";
connectAttr "joint19_rotateX.o" "joint19.rx";
connectAttr "joint19_rotateY.o" "joint19.ry";
connectAttr "joint19_rotateZ.o" "joint19.rz";
connectAttr "joint19.s" "joint20.is";
connectAttr "joint20_scaleX.o" "joint20.sx";
connectAttr "joint20_scaleY.o" "joint20.sy";
connectAttr "joint20_scaleZ.o" "joint20.sz";
connectAttr "joint20_translateX.o" "joint20.tx";
connectAttr "joint20_translateY.o" "joint20.ty";
connectAttr "joint20_translateZ.o" "joint20.tz";
connectAttr "joint20_visibility.o" "joint20.v";
connectAttr "joint20_rotateX.o" "joint20.rx";
connectAttr "joint20_rotateY.o" "joint20.ry";
connectAttr "joint20_rotateZ.o" "joint20.rz";
connectAttr "joint21_scaleX.o" "joint21.sx";
connectAttr "joint21_scaleY.o" "joint21.sy";
connectAttr "joint21_scaleZ.o" "joint21.sz";
connectAttr "joint20.s" "joint21.is";
connectAttr "joint21_translateX.o" "joint21.tx";
connectAttr "joint21_translateY.o" "joint21.ty";
connectAttr "joint21_translateZ.o" "joint21.tz";
connectAttr "joint21_visibility.o" "joint21.v";
connectAttr "joint21_rotateX.o" "joint21.rx";
connectAttr "joint21_rotateY.o" "joint21.ry";
connectAttr "joint21_rotateZ.o" "joint21.rz";
connectAttr "middleKraken.s" "back_right.is";
connectAttr "back_right_scaleX.o" "back_right.sx";
connectAttr "back_right_scaleY.o" "back_right.sy";
connectAttr "back_right_scaleZ.o" "back_right.sz";
connectAttr "back_right_translateX.o" "back_right.tx";
connectAttr "back_right_translateY.o" "back_right.ty";
connectAttr "back_right_translateZ.o" "back_right.tz";
connectAttr "back_right_visibility.o" "back_right.v";
connectAttr "back_right_rotateX.o" "back_right.rx";
connectAttr "back_right_rotateY.o" "back_right.ry";
connectAttr "back_right_rotateZ.o" "back_right.rz";
connectAttr "joint22_scaleX.o" "joint22.sx";
connectAttr "joint22_scaleY.o" "joint22.sy";
connectAttr "joint22_scaleZ.o" "joint22.sz";
connectAttr "back_right.s" "joint22.is";
connectAttr "joint22_translateX.o" "joint22.tx";
connectAttr "joint22_translateY.o" "joint22.ty";
connectAttr "joint22_translateZ.o" "joint22.tz";
connectAttr "joint22_visibility.o" "joint22.v";
connectAttr "joint22_rotateX.o" "joint22.rx";
connectAttr "joint22_rotateY.o" "joint22.ry";
connectAttr "joint22_rotateZ.o" "joint22.rz";
connectAttr "joint23_scaleX.o" "joint23.sx";
connectAttr "joint23_scaleY.o" "joint23.sy";
connectAttr "joint23_scaleZ.o" "joint23.sz";
connectAttr "joint22.s" "joint23.is";
connectAttr "joint23_translateX.o" "joint23.tx";
connectAttr "joint23_translateY.o" "joint23.ty";
connectAttr "joint23_translateZ.o" "joint23.tz";
connectAttr "joint23_visibility.o" "joint23.v";
connectAttr "joint23_rotateX.o" "joint23.rx";
connectAttr "joint23_rotateY.o" "joint23.ry";
connectAttr "joint23_rotateZ.o" "joint23.rz";
connectAttr "joint24_scaleX.o" "joint24.sx";
connectAttr "joint24_scaleY.o" "joint24.sy";
connectAttr "joint24_scaleZ.o" "joint24.sz";
connectAttr "joint23.s" "joint24.is";
connectAttr "joint24_translateX.o" "joint24.tx";
connectAttr "joint24_translateY.o" "joint24.ty";
connectAttr "joint24_translateZ.o" "joint24.tz";
connectAttr "joint24_visibility.o" "joint24.v";
connectAttr "joint24_rotateX.o" "joint24.rx";
connectAttr "joint24_rotateY.o" "joint24.ry";
connectAttr "joint24_rotateZ.o" "joint24.rz";
connectAttr "joint25_scaleX.o" "joint25.sx";
connectAttr "joint25_scaleY.o" "joint25.sy";
connectAttr "joint25_scaleZ.o" "joint25.sz";
connectAttr "joint24.s" "joint25.is";
connectAttr "joint25_translateX.o" "joint25.tx";
connectAttr "joint25_translateY.o" "joint25.ty";
connectAttr "joint25_translateZ.o" "joint25.tz";
connectAttr "joint25_visibility.o" "joint25.v";
connectAttr "joint25_rotateX.o" "joint25.rx";
connectAttr "joint25_rotateY.o" "joint25.ry";
connectAttr "joint25_rotateZ.o" "joint25.rz";
connectAttr "joint26_scaleX.o" "joint26.sx";
connectAttr "joint26_scaleY.o" "joint26.sy";
connectAttr "joint26_scaleZ.o" "joint26.sz";
connectAttr "joint25.s" "joint26.is";
connectAttr "joint26_translateX.o" "joint26.tx";
connectAttr "joint26_translateY.o" "joint26.ty";
connectAttr "joint26_translateZ.o" "joint26.tz";
connectAttr "joint26_visibility.o" "joint26.v";
connectAttr "joint26_rotateX.o" "joint26.rx";
connectAttr "joint26_rotateY.o" "joint26.ry";
connectAttr "joint26_rotateZ.o" "joint26.rz";
connectAttr "joint26.s" "joint27.is";
connectAttr "joint27_translateX.o" "joint27.tx";
connectAttr "joint27_translateY.o" "joint27.ty";
connectAttr "joint27_translateZ.o" "joint27.tz";
connectAttr "joint27_visibility.o" "joint27.v";
connectAttr "joint27_rotateX.o" "joint27.rx";
connectAttr "joint27_rotateY.o" "joint27.ry";
connectAttr "joint27_rotateZ.o" "joint27.rz";
connectAttr "joint27_scaleX.o" "joint27.sx";
connectAttr "joint27_scaleY.o" "joint27.sy";
connectAttr "joint27_scaleZ.o" "joint27.sz";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "blinn1SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "pasted__blinn1SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "blinn2SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "blinn3SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "blinn4SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "blinn5SG.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" "blinn6SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "blinn1SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "pasted__blinn1SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "blinn2SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "blinn3SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "blinn4SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "blinn5SG.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" "blinn6SG.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr "groupParts2.og" "tweak1.ip[0].ig";
connectAttr "groupId12.id" "tweak1.ip[0].gi";
connectAttr "groupId12.msg" "tweakSet1.gn" -na;
connectAttr "krakenShape.iog.og[3]" "tweakSet1.dsm" -na;
connectAttr "tweak1.msg" "tweakSet1.ub[0]";
connectAttr "krakenShapeOrig1.w" "groupParts2.ig";
connectAttr "groupId12.id" "groupParts2.gi";
connectAttr "skinCluster1GroupParts.og" "skinCluster1.ip[0].ig";
connectAttr "skinCluster1GroupId.id" "skinCluster1.ip[0].gi";
connectAttr "bindPose1.msg" "skinCluster1.bp";
connectAttr "middleKraken.wm" "skinCluster1.ma[0]";
connectAttr "right.wm" "skinCluster1.ma[1]";
connectAttr "joint28.wm" "skinCluster1.ma[2]";
connectAttr "joint29.wm" "skinCluster1.ma[3]";
connectAttr "joint30.wm" "skinCluster1.ma[4]";
connectAttr "joint31.wm" "skinCluster1.ma[5]";
connectAttr "joint32.wm" "skinCluster1.ma[6]";
connectAttr "front_right.wm" "skinCluster1.ma[7]";
connectAttr "joint1.wm" "skinCluster1.ma[8]";
connectAttr "joint2.wm" "skinCluster1.ma[9]";
connectAttr "joint3.wm" "skinCluster1.ma[10]";
connectAttr "joint4.wm" "skinCluster1.ma[11]";
connectAttr "joint5.wm" "skinCluster1.ma[12]";
connectAttr "front_left.wm" "skinCluster1.ma[13]";
connectAttr "joint6.wm" "skinCluster1.ma[14]";
connectAttr "joint7.wm" "skinCluster1.ma[15]";
connectAttr "joint8.wm" "skinCluster1.ma[16]";
connectAttr "joint9.wm" "skinCluster1.ma[17]";
connectAttr "joint10.wm" "skinCluster1.ma[18]";
connectAttr "left.wm" "skinCluster1.ma[19]";
connectAttr "joint11.wm" "skinCluster1.ma[20]";
connectAttr "joint12.wm" "skinCluster1.ma[21]";
connectAttr "joint13.wm" "skinCluster1.ma[22]";
connectAttr "joint14.wm" "skinCluster1.ma[23]";
connectAttr "joint15.wm" "skinCluster1.ma[24]";
connectAttr "back_left.wm" "skinCluster1.ma[25]";
connectAttr "joint16.wm" "skinCluster1.ma[26]";
connectAttr "joint17.wm" "skinCluster1.ma[27]";
connectAttr "joint18.wm" "skinCluster1.ma[28]";
connectAttr "joint19.wm" "skinCluster1.ma[29]";
connectAttr "joint20.wm" "skinCluster1.ma[30]";
connectAttr "joint21.wm" "skinCluster1.ma[31]";
connectAttr "back_right.wm" "skinCluster1.ma[32]";
connectAttr "joint22.wm" "skinCluster1.ma[33]";
connectAttr "joint23.wm" "skinCluster1.ma[34]";
connectAttr "joint24.wm" "skinCluster1.ma[35]";
connectAttr "joint25.wm" "skinCluster1.ma[36]";
connectAttr "joint26.wm" "skinCluster1.ma[37]";
connectAttr "joint27.wm" "skinCluster1.ma[38]";
connectAttr "middleKraken.liw" "skinCluster1.lw[0]";
connectAttr "right.liw" "skinCluster1.lw[1]";
connectAttr "joint28.liw" "skinCluster1.lw[2]";
connectAttr "joint29.liw" "skinCluster1.lw[3]";
connectAttr "joint30.liw" "skinCluster1.lw[4]";
connectAttr "joint31.liw" "skinCluster1.lw[5]";
connectAttr "joint32.liw" "skinCluster1.lw[6]";
connectAttr "front_right.liw" "skinCluster1.lw[7]";
connectAttr "joint1.liw" "skinCluster1.lw[8]";
connectAttr "joint2.liw" "skinCluster1.lw[9]";
connectAttr "joint3.liw" "skinCluster1.lw[10]";
connectAttr "joint4.liw" "skinCluster1.lw[11]";
connectAttr "joint5.liw" "skinCluster1.lw[12]";
connectAttr "front_left.liw" "skinCluster1.lw[13]";
connectAttr "joint6.liw" "skinCluster1.lw[14]";
connectAttr "joint7.liw" "skinCluster1.lw[15]";
connectAttr "joint8.liw" "skinCluster1.lw[16]";
connectAttr "joint9.liw" "skinCluster1.lw[17]";
connectAttr "joint10.liw" "skinCluster1.lw[18]";
connectAttr "left.liw" "skinCluster1.lw[19]";
connectAttr "joint11.liw" "skinCluster1.lw[20]";
connectAttr "joint12.liw" "skinCluster1.lw[21]";
connectAttr "joint13.liw" "skinCluster1.lw[22]";
connectAttr "joint14.liw" "skinCluster1.lw[23]";
connectAttr "joint15.liw" "skinCluster1.lw[24]";
connectAttr "back_left.liw" "skinCluster1.lw[25]";
connectAttr "joint16.liw" "skinCluster1.lw[26]";
connectAttr "joint17.liw" "skinCluster1.lw[27]";
connectAttr "joint18.liw" "skinCluster1.lw[28]";
connectAttr "joint19.liw" "skinCluster1.lw[29]";
connectAttr "joint20.liw" "skinCluster1.lw[30]";
connectAttr "joint21.liw" "skinCluster1.lw[31]";
connectAttr "back_right.liw" "skinCluster1.lw[32]";
connectAttr "joint22.liw" "skinCluster1.lw[33]";
connectAttr "joint23.liw" "skinCluster1.lw[34]";
connectAttr "joint24.liw" "skinCluster1.lw[35]";
connectAttr "joint25.liw" "skinCluster1.lw[36]";
connectAttr "joint26.liw" "skinCluster1.lw[37]";
connectAttr "joint27.liw" "skinCluster1.lw[38]";
connectAttr "middleKraken.obcc" "skinCluster1.ifcl[0]";
connectAttr "right.obcc" "skinCluster1.ifcl[1]";
connectAttr "joint28.obcc" "skinCluster1.ifcl[2]";
connectAttr "joint29.obcc" "skinCluster1.ifcl[3]";
connectAttr "joint30.obcc" "skinCluster1.ifcl[4]";
connectAttr "joint31.obcc" "skinCluster1.ifcl[5]";
connectAttr "joint32.obcc" "skinCluster1.ifcl[6]";
connectAttr "front_right.obcc" "skinCluster1.ifcl[7]";
connectAttr "joint1.obcc" "skinCluster1.ifcl[8]";
connectAttr "joint2.obcc" "skinCluster1.ifcl[9]";
connectAttr "joint3.obcc" "skinCluster1.ifcl[10]";
connectAttr "joint4.obcc" "skinCluster1.ifcl[11]";
connectAttr "joint5.obcc" "skinCluster1.ifcl[12]";
connectAttr "front_left.obcc" "skinCluster1.ifcl[13]";
connectAttr "joint6.obcc" "skinCluster1.ifcl[14]";
connectAttr "joint7.obcc" "skinCluster1.ifcl[15]";
connectAttr "joint8.obcc" "skinCluster1.ifcl[16]";
connectAttr "joint9.obcc" "skinCluster1.ifcl[17]";
connectAttr "joint10.obcc" "skinCluster1.ifcl[18]";
connectAttr "left.obcc" "skinCluster1.ifcl[19]";
connectAttr "joint11.obcc" "skinCluster1.ifcl[20]";
connectAttr "joint12.obcc" "skinCluster1.ifcl[21]";
connectAttr "joint13.obcc" "skinCluster1.ifcl[22]";
connectAttr "joint14.obcc" "skinCluster1.ifcl[23]";
connectAttr "joint15.obcc" "skinCluster1.ifcl[24]";
connectAttr "back_left.obcc" "skinCluster1.ifcl[25]";
connectAttr "joint16.obcc" "skinCluster1.ifcl[26]";
connectAttr "joint17.obcc" "skinCluster1.ifcl[27]";
connectAttr "joint18.obcc" "skinCluster1.ifcl[28]";
connectAttr "joint19.obcc" "skinCluster1.ifcl[29]";
connectAttr "joint20.obcc" "skinCluster1.ifcl[30]";
connectAttr "joint21.obcc" "skinCluster1.ifcl[31]";
connectAttr "back_right.obcc" "skinCluster1.ifcl[32]";
connectAttr "joint22.obcc" "skinCluster1.ifcl[33]";
connectAttr "joint23.obcc" "skinCluster1.ifcl[34]";
connectAttr "joint24.obcc" "skinCluster1.ifcl[35]";
connectAttr "joint25.obcc" "skinCluster1.ifcl[36]";
connectAttr "joint26.obcc" "skinCluster1.ifcl[37]";
connectAttr "joint27.obcc" "skinCluster1.ifcl[38]";
connectAttr "back_left.msg" "skinCluster1.ptt";
connectAttr "skinCluster1GroupId.msg" "skinCluster1Set.gn" -na;
connectAttr "krakenShape.iog.og[4]" "skinCluster1Set.dsm" -na;
connectAttr "skinCluster1.msg" "skinCluster1Set.ub[0]";
connectAttr "tweak1.og[0]" "skinCluster1GroupParts.ig";
connectAttr "skinCluster1GroupId.id" "skinCluster1GroupParts.gi";
connectAttr "kraken.msg" "bindPose1.m[0]";
connectAttr "middleKraken.msg" "bindPose1.m[1]";
connectAttr "right.msg" "bindPose1.m[2]";
connectAttr "joint28.msg" "bindPose1.m[3]";
connectAttr "joint29.msg" "bindPose1.m[4]";
connectAttr "joint30.msg" "bindPose1.m[5]";
connectAttr "joint31.msg" "bindPose1.m[6]";
connectAttr "joint32.msg" "bindPose1.m[7]";
connectAttr "front_right.msg" "bindPose1.m[8]";
connectAttr "joint1.msg" "bindPose1.m[9]";
connectAttr "joint2.msg" "bindPose1.m[10]";
connectAttr "joint3.msg" "bindPose1.m[11]";
connectAttr "joint4.msg" "bindPose1.m[12]";
connectAttr "joint5.msg" "bindPose1.m[13]";
connectAttr "front_left.msg" "bindPose1.m[14]";
connectAttr "joint6.msg" "bindPose1.m[15]";
connectAttr "joint7.msg" "bindPose1.m[16]";
connectAttr "joint8.msg" "bindPose1.m[17]";
connectAttr "joint9.msg" "bindPose1.m[18]";
connectAttr "joint10.msg" "bindPose1.m[19]";
connectAttr "left.msg" "bindPose1.m[20]";
connectAttr "joint11.msg" "bindPose1.m[21]";
connectAttr "joint12.msg" "bindPose1.m[22]";
connectAttr "joint13.msg" "bindPose1.m[23]";
connectAttr "joint14.msg" "bindPose1.m[24]";
connectAttr "joint15.msg" "bindPose1.m[25]";
connectAttr "back_left.msg" "bindPose1.m[26]";
connectAttr "joint16.msg" "bindPose1.m[27]";
connectAttr "joint17.msg" "bindPose1.m[28]";
connectAttr "joint18.msg" "bindPose1.m[29]";
connectAttr "joint19.msg" "bindPose1.m[30]";
connectAttr "joint20.msg" "bindPose1.m[31]";
connectAttr "joint21.msg" "bindPose1.m[32]";
connectAttr "back_right.msg" "bindPose1.m[33]";
connectAttr "joint22.msg" "bindPose1.m[34]";
connectAttr "joint23.msg" "bindPose1.m[35]";
connectAttr "joint24.msg" "bindPose1.m[36]";
connectAttr "joint25.msg" "bindPose1.m[37]";
connectAttr "joint26.msg" "bindPose1.m[38]";
connectAttr "joint27.msg" "bindPose1.m[39]";
connectAttr "bindPose1.w" "bindPose1.p[0]";
connectAttr "bindPose1.m[0]" "bindPose1.p[1]";
connectAttr "bindPose1.m[1]" "bindPose1.p[2]";
connectAttr "bindPose1.m[2]" "bindPose1.p[3]";
connectAttr "bindPose1.m[3]" "bindPose1.p[4]";
connectAttr "bindPose1.m[4]" "bindPose1.p[5]";
connectAttr "bindPose1.m[5]" "bindPose1.p[6]";
connectAttr "bindPose1.m[6]" "bindPose1.p[7]";
connectAttr "bindPose1.m[1]" "bindPose1.p[8]";
connectAttr "bindPose1.m[8]" "bindPose1.p[9]";
connectAttr "bindPose1.m[9]" "bindPose1.p[10]";
connectAttr "bindPose1.m[10]" "bindPose1.p[11]";
connectAttr "bindPose1.m[11]" "bindPose1.p[12]";
connectAttr "bindPose1.m[12]" "bindPose1.p[13]";
connectAttr "bindPose1.m[1]" "bindPose1.p[14]";
connectAttr "bindPose1.m[14]" "bindPose1.p[15]";
connectAttr "bindPose1.m[15]" "bindPose1.p[16]";
connectAttr "bindPose1.m[16]" "bindPose1.p[17]";
connectAttr "bindPose1.m[17]" "bindPose1.p[18]";
connectAttr "bindPose1.m[18]" "bindPose1.p[19]";
connectAttr "bindPose1.m[1]" "bindPose1.p[20]";
connectAttr "bindPose1.m[20]" "bindPose1.p[21]";
connectAttr "bindPose1.m[21]" "bindPose1.p[22]";
connectAttr "bindPose1.m[22]" "bindPose1.p[23]";
connectAttr "bindPose1.m[23]" "bindPose1.p[24]";
connectAttr "bindPose1.m[24]" "bindPose1.p[25]";
connectAttr "bindPose1.m[1]" "bindPose1.p[26]";
connectAttr "bindPose1.m[26]" "bindPose1.p[27]";
connectAttr "bindPose1.m[27]" "bindPose1.p[28]";
connectAttr "bindPose1.m[28]" "bindPose1.p[29]";
connectAttr "bindPose1.m[29]" "bindPose1.p[30]";
connectAttr "bindPose1.m[30]" "bindPose1.p[31]";
connectAttr "bindPose1.m[31]" "bindPose1.p[32]";
connectAttr "bindPose1.m[1]" "bindPose1.p[33]";
connectAttr "bindPose1.m[33]" "bindPose1.p[34]";
connectAttr "bindPose1.m[34]" "bindPose1.p[35]";
connectAttr "bindPose1.m[35]" "bindPose1.p[36]";
connectAttr "bindPose1.m[36]" "bindPose1.p[37]";
connectAttr "bindPose1.m[37]" "bindPose1.p[38]";
connectAttr "bindPose1.m[38]" "bindPose1.p[39]";
connectAttr "middleKraken.bps" "bindPose1.wm[1]";
connectAttr "right.bps" "bindPose1.wm[2]";
connectAttr "joint28.bps" "bindPose1.wm[3]";
connectAttr "joint29.bps" "bindPose1.wm[4]";
connectAttr "joint30.bps" "bindPose1.wm[5]";
connectAttr "joint31.bps" "bindPose1.wm[6]";
connectAttr "joint32.bps" "bindPose1.wm[7]";
connectAttr "front_right.bps" "bindPose1.wm[8]";
connectAttr "joint1.bps" "bindPose1.wm[9]";
connectAttr "joint2.bps" "bindPose1.wm[10]";
connectAttr "joint3.bps" "bindPose1.wm[11]";
connectAttr "joint4.bps" "bindPose1.wm[12]";
connectAttr "joint5.bps" "bindPose1.wm[13]";
connectAttr "front_left.bps" "bindPose1.wm[14]";
connectAttr "joint6.bps" "bindPose1.wm[15]";
connectAttr "joint7.bps" "bindPose1.wm[16]";
connectAttr "joint8.bps" "bindPose1.wm[17]";
connectAttr "joint9.bps" "bindPose1.wm[18]";
connectAttr "joint10.bps" "bindPose1.wm[19]";
connectAttr "left.bps" "bindPose1.wm[20]";
connectAttr "joint11.bps" "bindPose1.wm[21]";
connectAttr "joint12.bps" "bindPose1.wm[22]";
connectAttr "joint13.bps" "bindPose1.wm[23]";
connectAttr "joint14.bps" "bindPose1.wm[24]";
connectAttr "joint15.bps" "bindPose1.wm[25]";
connectAttr "back_left.bps" "bindPose1.wm[26]";
connectAttr "joint16.bps" "bindPose1.wm[27]";
connectAttr "joint17.bps" "bindPose1.wm[28]";
connectAttr "joint18.bps" "bindPose1.wm[29]";
connectAttr "joint19.bps" "bindPose1.wm[30]";
connectAttr "joint20.bps" "bindPose1.wm[31]";
connectAttr "joint21.bps" "bindPose1.wm[32]";
connectAttr "back_right.bps" "bindPose1.wm[33]";
connectAttr "joint22.bps" "bindPose1.wm[34]";
connectAttr "joint23.bps" "bindPose1.wm[35]";
connectAttr "joint24.bps" "bindPose1.wm[36]";
connectAttr "joint25.bps" "bindPose1.wm[37]";
connectAttr "joint26.bps" "bindPose1.wm[38]";
connectAttr "joint27.bps" "bindPose1.wm[39]";
connectAttr "blinn1.oc" "blinn1SG.ss";
connectAttr "krakenPondShape.iog" "blinn1SG.dsm" -na;
connectAttr "flagShape.iog" "blinn1SG.dsm" -na;
connectAttr "wood_of_flagShape.iog" "blinn1SG.dsm" -na;
connectAttr "blinn1SG.msg" "materialInfo1.sg";
connectAttr "blinn1.msg" "materialInfo1.m";
connectAttr "file1.msg" "materialInfo1.t" -na;
connectAttr ":defaultColorMgtGlobals.cme" "file1.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "file1.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "file1.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "file1.ws";
connectAttr "place2dTexture1.c" "file1.c";
connectAttr "place2dTexture1.tf" "file1.tf";
connectAttr "place2dTexture1.rf" "file1.rf";
connectAttr "place2dTexture1.mu" "file1.mu";
connectAttr "place2dTexture1.mv" "file1.mv";
connectAttr "place2dTexture1.s" "file1.s";
connectAttr "place2dTexture1.wu" "file1.wu";
connectAttr "place2dTexture1.wv" "file1.wv";
connectAttr "place2dTexture1.re" "file1.re";
connectAttr "place2dTexture1.of" "file1.of";
connectAttr "place2dTexture1.r" "file1.ro";
connectAttr "place2dTexture1.n" "file1.n";
connectAttr "place2dTexture1.vt1" "file1.vt1";
connectAttr "place2dTexture1.vt2" "file1.vt2";
connectAttr "place2dTexture1.vt3" "file1.vt3";
connectAttr "place2dTexture1.vc1" "file1.vc1";
connectAttr "place2dTexture1.o" "file1.uv";
connectAttr "place2dTexture1.ofs" "file1.fs";
connectAttr "pasted__file1.oc" "pasted__blinn1.c";
connectAttr "pasted__blinn1.oc" "pasted__blinn1SG.ss";
connectAttr "pasted__blinn1SG.msg" "pasted__materialInfo1.sg";
connectAttr "pasted__blinn1.msg" "pasted__materialInfo1.m";
connectAttr "pasted__file1.msg" "pasted__materialInfo1.t" -na;
connectAttr ":defaultColorMgtGlobals.cme" "pasted__file1.cme";
connectAttr ":defaultColorMgtGlobals.cfe" "pasted__file1.cmcf";
connectAttr ":defaultColorMgtGlobals.cfp" "pasted__file1.cmcp";
connectAttr ":defaultColorMgtGlobals.wsn" "pasted__file1.ws";
connectAttr "pasted__place2dTexture1.c" "pasted__file1.c";
connectAttr "pasted__place2dTexture1.tf" "pasted__file1.tf";
connectAttr "pasted__place2dTexture1.rf" "pasted__file1.rf";
connectAttr "pasted__place2dTexture1.mu" "pasted__file1.mu";
connectAttr "pasted__place2dTexture1.mv" "pasted__file1.mv";
connectAttr "pasted__place2dTexture1.s" "pasted__file1.s";
connectAttr "pasted__place2dTexture1.wu" "pasted__file1.wu";
connectAttr "pasted__place2dTexture1.wv" "pasted__file1.wv";
connectAttr "pasted__place2dTexture1.re" "pasted__file1.re";
connectAttr "pasted__place2dTexture1.of" "pasted__file1.of";
connectAttr "pasted__place2dTexture1.r" "pasted__file1.ro";
connectAttr "pasted__place2dTexture1.n" "pasted__file1.n";
connectAttr "pasted__place2dTexture1.vt1" "pasted__file1.vt1";
connectAttr "pasted__place2dTexture1.vt2" "pasted__file1.vt2";
connectAttr "pasted__place2dTexture1.vt3" "pasted__file1.vt3";
connectAttr "pasted__place2dTexture1.vc1" "pasted__file1.vc1";
connectAttr "pasted__place2dTexture1.o" "pasted__file1.uv";
connectAttr "pasted__place2dTexture1.ofs" "pasted__file1.fs";
connectAttr "pasted__blinn1.msg" "pasted__hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[0].dn"
		;
connectAttr "pasted__place2dTexture1.msg" "pasted__hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[1].dn"
		;
connectAttr "pasted__blinn1SG.msg" "pasted__hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[2].dn"
		;
connectAttr "pasted__file1.msg" "pasted__hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[3].dn"
		;
connectAttr "main_colour.oc" "blinn2SG.ss";
connectAttr "krakenShape.iog.og[5]" "blinn2SG.dsm" -na;
connectAttr "groupId13.msg" "blinn2SG.gn" -na;
connectAttr "blinn2SG.msg" "materialInfo2.sg";
connectAttr "main_colour.msg" "materialInfo2.m";
connectAttr "file1.oc" "blinn1.c";
connectAttr "eyecolour.oc" "blinn3SG.ss";
connectAttr "groupId14.msg" "blinn3SG.gn" -na;
connectAttr "krakenShape.iog.og[6]" "blinn3SG.dsm" -na;
connectAttr "blinn3SG.msg" "materialInfo3.sg";
connectAttr "eyecolour.msg" "materialInfo3.m";
connectAttr "skinCluster1.og[0]" "groupParts3.ig";
connectAttr "groupParts3.og" "groupParts4.ig";
connectAttr "middle_eye.oc" "blinn4SG.ss";
connectAttr "groupId15.msg" "blinn4SG.gn" -na;
connectAttr "krakenShape.iog.og[7]" "blinn4SG.dsm" -na;
connectAttr "blinn4SG.msg" "materialInfo4.sg";
connectAttr "middle_eye.msg" "materialInfo4.m";
connectAttr "groupParts4.og" "groupParts5.ig";
connectAttr "bottom_eye.oc" "blinn5SG.ss";
connectAttr "groupId16.msg" "blinn5SG.gn" -na;
connectAttr "krakenShape.iog.og[8]" "blinn5SG.dsm" -na;
connectAttr "blinn5SG.msg" "materialInfo5.sg";
connectAttr "bottom_eye.msg" "materialInfo5.m";
connectAttr "groupParts5.og" "groupParts6.ig";
connectAttr "krekenhead.oc" "blinn6SG.ss";
connectAttr "groupId17.msg" "blinn6SG.gn" -na;
connectAttr "krakenShape.iog.og[9]" "blinn6SG.dsm" -na;
connectAttr "blinn6SG.msg" "materialInfo6.sg";
connectAttr "krekenhead.msg" "materialInfo6.m";
connectAttr "groupParts6.og" "groupParts7.ig";
connectAttr "place2dTexture1.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[0].dn"
		;
connectAttr "blinn1SG.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[1].dn"
		;
connectAttr "file1.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[2].dn"
		;
connectAttr "main_colour.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[3].dn"
		;
connectAttr "blinn2SG.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[4].dn"
		;
connectAttr "blinn1.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[5].dn"
		;
connectAttr "eyecolour.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[6].dn"
		;
connectAttr "blinn3SG.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[7].dn"
		;
connectAttr "middle_eye.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[8].dn"
		;
connectAttr "blinn4SG.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[9].dn"
		;
connectAttr "bottom_eye.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[10].dn"
		;
connectAttr "blinn5SG.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[11].dn"
		;
connectAttr "krekenhead.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[12].dn"
		;
connectAttr "blinn6SG.msg" "hyperShadePrimaryNodeEditorSavedTabsInfo.tgi[0].ni[13].dn"
		;
connectAttr "groupParts7.og" "groupParts8.ig";
connectAttr "groupParts8.og" "groupParts9.ig";
connectAttr "groupParts9.og" "groupParts10.ig";
connectAttr "groupParts10.og" "groupParts11.ig";
connectAttr "groupParts11.og" "groupParts12.ig";
connectAttr "groupParts12.og" "groupParts13.ig";
connectAttr "groupId13.id" "groupParts13.gi";
connectAttr "groupParts13.og" "groupParts14.ig";
connectAttr "groupId14.id" "groupParts14.gi";
connectAttr "groupParts14.og" "groupParts15.ig";
connectAttr "groupId15.id" "groupParts15.gi";
connectAttr "groupParts15.og" "groupParts16.ig";
connectAttr "groupId16.id" "groupParts16.gi";
connectAttr "groupParts16.og" "groupParts17.ig";
connectAttr "groupId17.id" "groupParts17.gi";
connectAttr "blinn1SG.pa" ":renderPartition.st" -na;
connectAttr "pasted__blinn1SG.pa" ":renderPartition.st" -na;
connectAttr "blinn2SG.pa" ":renderPartition.st" -na;
connectAttr "blinn3SG.pa" ":renderPartition.st" -na;
connectAttr "blinn4SG.pa" ":renderPartition.st" -na;
connectAttr "blinn5SG.pa" ":renderPartition.st" -na;
connectAttr "blinn6SG.pa" ":renderPartition.st" -na;
connectAttr "blinn1.msg" ":defaultShaderList1.s" -na;
connectAttr "pasted__blinn1.msg" ":defaultShaderList1.s" -na;
connectAttr "main_colour.msg" ":defaultShaderList1.s" -na;
connectAttr "eyecolour.msg" ":defaultShaderList1.s" -na;
connectAttr "middle_eye.msg" ":defaultShaderList1.s" -na;
connectAttr "bottom_eye.msg" ":defaultShaderList1.s" -na;
connectAttr "krekenhead.msg" ":defaultShaderList1.s" -na;
connectAttr "place2dTexture1.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "pasted__place2dTexture1.msg" ":defaultRenderUtilityList1.u" -na;
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "file1.msg" ":defaultTextureList1.tx" -na;
connectAttr "pasted__file1.msg" ":defaultTextureList1.tx" -na;
// End of kraken.ma
