$("#test").on('click', function (e) {
    e.preventDefault();
    swal.fire({
        allowOutsideClick: false,
        title: '登出帳戶？',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        allowOutsideClick: false,//不可點背景關閉
        cancelButtonText: '取消',
        confirmButtonText: '確定'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: 'logout.aspx',
                type: 'post',
                dataType: 'json',
                async: false,//啟用同步請求
                success: function (result) {
                    console.log("OK")
                },
                error: function (e) {
                    console.log(e);
                }
            });
            swal.fire({
                icon: 'success',
                title: '登出成功!',
                showConfirmButton: false,
                timer: 1000,
                allowOutsideClick: false //不可點背景關閉
            }).then(function () {
                location.href = 'Logon';
            });
        }
    });
});
