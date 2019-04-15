const lighthouse = require('{NODE_MODULES}\\lighthouse');
const chromeLauncher = require('{NODE_MODULES}\\lighthouse\\node_modules\\chrome-launcher');


function launchChromeAndRunLighthouse(url, opts, config = null) {
    return chromeLauncher.launch({ chromeFlags: opts.chromeFlags }).then(chrome => {
        opts.port = chrome.port;
        return lighthouse(url, opts, config).then(results => {
            return chrome.kill().then(() => results.lhr);
        });
    });
}

const opts = {OPTIONS};

launchChromeAndRunLighthouse('{URL}', opts).then(results => {
    console.log(JSON.stringify(results));
});