$(function myfunction() {
    var scene = new THREE.Scene();
    scene.background = new THREE.Color(0xdddddd);
    var camera = getDeffaultCamera();
    var renderer = getRenderer();
    var controls = new THREE.OrbitControls(camera, renderer.domElement);
    controls.update();
    var cube = drawCube(scene);
    cube.position.set(-200, 0, 0);
    //scene.add(drawLine());
    drawText(scene);
    drawModel(scene);
    drawLights(scene);

    var animate = function () {//render loop
        requestAnimationFrame(animate);
        /*cube.rotation.x += 0.01;
        cube.rotation.y += 0.01;*/
        controls.update();
        renderer.render(scene, camera);
    };

    if (WEBGL.isWebGLAvailable()) {
        animate();
    } else {
        var warning = WEBGL.getWebGLErrorMessage();
        document.getElementById('root_page').appendChild(warning);
    }
    if (!WEBGL.isWebGL2Available()) {
        var warning2 = WEBGL.getWebGLErrorMessage();
        warning2.innerText += warning2.innerText + '2';
        document.getElementById('root_page').appendChild(warning2);
    }
});

function getRenderer()
{
    var renderer = new THREE.WebGLRenderer();
    let render_elem = document.getElementById('render_scene');
    renderer.setSize(render_elem.offsetWidth, render_elem.offsetWidth);
    render_elem.appendChild(renderer.domElement);
    return renderer;
}

function getDeffaultCamera()
{
    var camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
    camera.position.set(0, 0, 200);
    camera.lookAt(0, 0, 0);
    return camera;
}

function drawLine()
{
    var material = new THREE.LineBasicMaterial({ color: 0x0000ff });
    var points = [];
    points.push(new THREE.Vector3(- 30, 0, 0));
    points.push(new THREE.Vector3(0, 30, 0));
    points.push(new THREE.Vector3(30, 0, 0));

    var geometry = new THREE.BufferGeometry().setFromPoints(points);
    var line = new THREE.Line(geometry, material);
    return line;
}

function drawText(scene)
{
    var textGeometry = null;
    let loader = new THREE.FontLoader();
    loader.load('Fonts/Authem', function (font) {
        textGeometry = new THREE.TextGeometry('Text example', {
            font: font,
            size: 30,
            height: 1,
            curveSegments: 12,
            bevelEnabled: false,
            bevelThickness: 3,
            bevelSize: 1,
            bevelOffset: 0,
            bevelSegments: 3
        });
    });
    if (!textGeometry) {
        setTimeout(function myfunction() {
            var material = new THREE.MeshBasicMaterial({ color: 0x00ff00 });
            var text = new THREE.Mesh(textGeometry, material);
            text.position.set(100, 0, 0);
            scene.add(text);
        }, 1000);
    }
}

function drawCube(scene)
{
    var geometry = new THREE.BoxGeometry(50, 50, 50);
    var material = new THREE.MeshBasicMaterial({ color: 0x00ff00 });
    var cube = new THREE.Mesh(geometry, material);
    scene.add(cube);//add to 0.0.0 position
    return cube;
}

function drawModel(scene)
{
    var loader = new THREE.GLTFLoader();
    loader.load('http://localhost:49504/Content/models/skull/scene.gltf', function (gltf) {
        var model = gltf.scene.children[0];
        model.scale.set(50, 50, 50);
        scene.add(gltf.scene);
    }, undefined, function (error) {
        console.error(error);
    });
}

function drawLights(scene) {
    hlight = new THREE.AmbientLight(0x404040, 100);
    scene.add(hlight);
    directionalLight = new THREE.DirectionalLight(0xffffff, 1);
    directionalLight.position.set(0, 1, 0);
    directionalLight.castShadow = true;
    scene.add(directionalLight);
    light = new THREE.PointLight(0xc4c4c4, 1, 100, 2);
    light.position.set(0, 300, 500);
    scene.add(light);
    light2 = new THREE.PointLight(0xc4c4c4, 1, 100, 2);
    light2.position.set(500, 100, 0);
    scene.add(light2);
    light3 = new THREE.PointLight(0xc4c4c4, 1, 100, 2);
    light3.position.set(0, 100, -500);
    scene.add(light3);
    light4 = new THREE.PointLight(0xc4c4c4, 1, 100, 2);
    light4.position.set(-500, 300, 500);
    scene.add(light4);
}
