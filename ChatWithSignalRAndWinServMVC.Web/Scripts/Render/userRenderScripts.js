$(function myfunction() {
    var scene = new THREE.Scene();
    var camera = getDeffaultCamera();
    var renderer = getRenderer();

    var geometry = new THREE.BoxGeometry();
    var material = new THREE.MeshBasicMaterial({ color: 0x00ff00 });
    var cube = new THREE.Mesh(geometry, material);
    scene.add(cube);//add to 0.0.0 position

    var animate = function () {//render loop
        requestAnimationFrame(animate);
        cube.rotation.x += 0.01;
        cube.rotation.y += 0.01;
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
    //                                      fov     qspect ratio                         near  far
    var camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
    camera.position.z = 5;//move camera
    return camera;
}